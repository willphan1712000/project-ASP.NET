using ASP.NET_Web.Models;
using Microsoft.AspNetCore.Identity;

namespace ASP.NET_Web.Seeder;

public static class RoleSeeder
{
    public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
    {
        // Resolve the RoleManager and UserManager from the DI container
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

        // 1. Create the Admin Role
        string[] roleNames = { "Admin", "Customer" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                // Create the role if it doesn't exist
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // 2. Create a default Admin User
        var adminEmail = "admin@yourdomain.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            var newAdmin = new User
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var createPowerUser = await userManager.CreateAsync(newAdmin, "SuperSecretPassword123!");
            
            if (createPowerUser.Succeeded)
            {
                // 3. Assign the new user to the Admin role
                await userManager.AddToRoleAsync(newAdmin, "Admin");
            }
        }
    }
}