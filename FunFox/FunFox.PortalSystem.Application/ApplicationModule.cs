using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using FunFox.PortalSystem.Application.Profiles;
using FunFox.PortalSystem.Application.Services.PlantServices;
using FunFox.PortalSystem.Application.Services.ClassServices;

namespace FunFox.PortalSystem.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplicationModule(this IServiceCollection services)
    {
        services.AddSingleton(provider => new MapperConfiguration(cfg =>
        {
            cfg.AddProfiles(MapperProfiles.GetAssemblyProfiles());
        }).CreateMapper());

        services.AddTransient<IPlantService, PlantService>();
        services.AddTransient<IClassService, ClassService>();

        return services;
    }
}