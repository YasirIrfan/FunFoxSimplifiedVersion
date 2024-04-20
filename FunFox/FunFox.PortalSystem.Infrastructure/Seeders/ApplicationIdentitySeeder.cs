using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Security.Claims;
using FunFox.PortalSystem.Domain.Entities;

namespace FunFox.PortalSystem.Infrastructure.Seeders;

public static class ApplicationIdentitySeeder
{
    public static async Task Run(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        await SeedRoles(roleManager);

        using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        await SeedUsers(userManager);
    }

    private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        string[] roles = {
            "Admin",
            "User"
        };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    private static async Task SeedUsers(UserManager<User> userManager)
    {
        // Default Admin User Creation
        //var adminUser = await userManager.FindByEmailAsync("admin@pms.local");
        var adminUser = await userManager.FindByEmailAsync("portaladmin@gmail.com");
        if (adminUser == null)
        {
            var result = await userManager.CreateAsync(new User
            {
                FirstName = "Admin",
                LastName = "User",
                Email = "portaladmin@gmail.com",
                UserName = "portaladmin@gmail.com",
                TwoFactorEnabled = false,
            }, "1234@Qwer");

            if (result.Succeeded)
            {
                adminUser = await userManager.FindByEmailAsync("portaladmin@gmail.com");
                var emailToken = await userManager.GenerateEmailConfirmationTokenAsync(adminUser);
                var emailConfirmationResult = await userManager.ConfirmEmailAsync(adminUser, emailToken);
                if (emailConfirmationResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }

        // Default Admin User Creation
        var user = await userManager.FindByEmailAsync("user@funfox.local");
        if (user == null)
        {
            var result = await userManager.CreateAsync(new User
            {
                FirstName = "General",
                LastName = "User",
                Email = "user@funfox.local",
                UserName = "user@funfox.local",
                TwoFactorEnabled = false,
            }, "1234@Qwer");

            if (result.Succeeded)
            {
                user = await userManager.FindByEmailAsync("user@funfox.local");
                var emailToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var emailConfirmationResult = await userManager.ConfirmEmailAsync(user, emailToken);
                if (emailConfirmationResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                }
            }
        }
    }
}