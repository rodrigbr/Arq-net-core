using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arq.Spotify.Application.Contracts.Spotify;
using Arq.Spotify.Application.Implementations.Spotify;
using Arq.Spotify.Infra.Configuration;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Arq.Spotify.Application
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services, string connectionString)
        {
            services.RegisterRepository(connectionString);

            services.AddMediatR(typeof(ConfigurationModule).Assembly);
            services.AddAutoMapper(typeof(ConfigurationModule).Assembly);

            services.AddScoped<IAlbumServices, AlbumServices>();

            return services;
        }
    }
}
