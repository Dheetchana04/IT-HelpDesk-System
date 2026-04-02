using Microsoft.AspNetCore.Identity;

namespace ITDesk.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            // Role Manager
            var roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // User Manager
            var userManager =
                serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { "Employee", "ITSupport", "Admin" };

            // Create Roles
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Create Default Admin User
            string adminEmail = "admin@itdesk.com";
            string adminPassword = "Admin@123";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var user = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
