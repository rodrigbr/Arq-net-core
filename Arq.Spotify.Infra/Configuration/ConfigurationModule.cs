using Arq.Spotify.Domain.Contracts.Repositories;
using Arq.Spotify.Domain.Contracts.Repositories.Spotify;
using Arq.Spotify.Domain.Contracts.Repositories.User;
using Arq.Spotify.Infra.Context;
using Arq.Spotify.Infra.Repositories;
using Arq.Spotify.Infra.Repositories.Spotify;
using Arq.Spotify.Infra.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Arq.Spotify.Infra.Configuration
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SpotifyContext>(c => c.UseSqlServer(connectionString));

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IMusicRepository, MusicRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserFavoriteMusicRepository, UserFavoriteMusicRepository>();

            return services;
        }
    }
}
