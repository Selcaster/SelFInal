using System.Text;
using Musico.BL.DTOs.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Musico.BL.Services;

namespace Musico.API;

public static class ServiceRegistration
{
    public static IServiceCollection AddJwtOptions(this IServiceCollection services,IConfiguration Configuration)
    {
        services.Configure<JwtOptions>(Configuration.GetSection(JwtOptions.Jwt));
        return services;
    }
    public static IServiceCollection AddEmailOptions(this IServiceCollection services,IConfiguration Configuration)
    {
        services.Configure<EmailOptions>(Configuration.GetSection(EmailOptions.Name));
        return services;
    }
    public static IServiceCollection AddAuth(this IServiceCollection services,IConfiguration Configuration)
    {
        JwtOptions jwtOpt = new JwtOptions();
        jwtOpt.Issuer = Configuration.GetRequiredSection("JwtOptions")["Issuer"]!;
        jwtOpt.Audience = Configuration.GetRequiredSection("JwtOptions")["Audience"]!;
        jwtOpt.SecretKey = Configuration.GetRequiredSection("JwtOptions")["SecretKey"]!;
        var signInKey  = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpt.SecretKey));
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    
                    IssuerSigningKey =signInKey,
                    ValidAudience = jwtOpt.Audience,
                    ValidIssuer = jwtOpt.Issuer,
                    ClockSkew = TimeSpan.Zero
                    
                };
            });
        
        return services;
    }

}