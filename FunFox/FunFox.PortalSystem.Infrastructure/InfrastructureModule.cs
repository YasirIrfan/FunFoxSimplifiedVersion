using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FunFox.PortalSystem.Application;
using FunFox.PortalSystem.Domain.Entities;
using FunFox.PortalSystem.Infrastructure.DbContexts;

namespace FunFox.PortalSystem.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}