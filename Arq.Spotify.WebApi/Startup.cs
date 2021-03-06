using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arq.Spotify.Application;
using Arq.Spotify.Domain.Contracts.Repositories;
using Arq.Spotify.Infra.Context;
using Arq.Spotify.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Arq.Spotify.Infra.Repositories.Spotify;
using Arq.Spotify.Domain.Contracts.Repositories.Spotify;
using Arq.Spotify.Domain.Contracts.Repositories.User;
using Arq.Spotify.Infra.Configuration;
using Arq.Spotify.Infra.Repositories.User;
using IdentityModel;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.DataProtection;

namespace Arq.Spotify.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.RegisterApplication(Configuration.GetConnectionString("SpotifyDB"));

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(opt =>
                {
                    opt.Authority = "https://spotify-identity-server.azurewebsites.net/";
                    opt.ApiName = "SpotifyLite";
                    opt.ApiSecret = "SuperSenhaDificil";
                });

            services.AddAuthorization(options =>
            {
               options.AddPolicy("user-policy", p =>
               {
                   p.RequireClaim("role", "spotify-user");
               });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Arq.Spotify.WebApi", Version = "v1" });
                OpenApiSecurityScheme securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securitySchema);

                OpenApiSecurityRequirement securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(securitySchema, new[] { "Bearer" });
                c.AddSecurityRequirement(securityRequirement);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Arq.Spotify.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
