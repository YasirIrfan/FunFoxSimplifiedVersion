using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FunFox.PortalSystem.Infrastructure.DbContexts;

namespace FunFox.PortalSystem.Infrastructure.Seeders;

public static class MainSeeder
{
    public static IHost Seed(this IHost host)
    {
        var services = host.Services;
        using var scope = services.CreateScope();
        using var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        if (appContext.Database.GetPendingMigrations().Any())
        {
            appContext.Database.Migrate();
        }

        ApplicationIdentitySeeder.Run(services).Wait();
        ClassSeeder.Run(services).Wait();
        //PlanetSeeder.Run(services).Wait();
        return host;
    }
}