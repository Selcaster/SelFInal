using Musico.Core.Repositories;
using Musico.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Musico.DAL;

public static class ServiceRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISongRepository, SongRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPlaylistSongRepository, PlaylistSongRepository>();
        services.AddScoped<IPlaylistRepository, PlaylistRepository>();
        services.AddScoped<ILikedSongRepository, LikedSongRepository>();
        services.AddScoped<IArtistRepository, ArtistRepository>();
        services.AddScoped<IAlbumRepository, AlbumRepository>();
        return services;
    }
}