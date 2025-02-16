using Microsoft.Extensions.DependencyInjection;
using Musico.BL.Services.Implements;
using Musico.BL.Services.Interfaces;

namespace Musico.BL;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        //services.AddScoped<IArtistService, ArtistService>();
        //services.AddScoped<IPlaylistService, PlaylistService>();
        //services.AddScoped<ISongService, SongService>();

        return services;
    }

    //public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    //{
    //    services.AddFluentValidationAutoValidation();
    //    services.AddValidatorsFromAssemblyContaining(typeof(ServiceRegistration));
    //    return services;
    //}

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServiceRegistration));
        return services;
    }
}
