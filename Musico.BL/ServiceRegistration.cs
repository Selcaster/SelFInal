using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Musico.BL.Services;
using Musico.Core.Entities;
using Musico.Core.Repositories;
using Musico.DAL.Repositories;
namespace Musico.BL;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ISearchService, SearchService>();
        services.AddScoped<IRecommendationService, RecommendationService>();
        services.AddScoped<IGenericRepository<Artist>, GenericRepository<Artist>>();


        return services;
    }

    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining(typeof(ServiceRegistration));
        return services;
    }


    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServiceRegistration));
        return services;
    }
}
