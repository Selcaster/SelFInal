using Musico.API;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using FluentValidation;
using FluentValidation.AspNetCore;
using Musico.BL;
using Musico.BL.Services;
using Musico.DAL;
using Musico.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Musico.BL.ExternalServices.Implements;
using Musico.BL.ExternalServices.Interfaces;
using Musico.Core.Entities;
using Musico.Core.Repositories;
using Musico.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddDbContext<MusicoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSql")));
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddJwtOptions(builder.Configuration);
builder.Services.AddEmailOptions(builder.Configuration);
builder.Services.AddScoped<IJwtTokenHandler, JwtTokenHandler>();//100
builder.Services.AddScoped<ICurrentUser, CurrentUser>();//100
builder.Services.AddScoped<IGenericRepository<Song>, GenericRepository<Song>>();//100
builder.Services.AddScoped<IGenericRepository<Artist>, GenericRepository<Artist>>();//100
builder.Services.AddScoped<IGenericRepository<Playlist>, GenericRepository<Playlist>>();//100
builder.Services.AddScoped<IGenericRepository<LikedSong>, GenericRepository<LikedSong>>();//100
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddFluentValidation();
builder.Services.AddAutoMapper();
builder.Services.AddMemoryCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.EnablePersistAuthorization();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();