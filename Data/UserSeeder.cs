using Microsoft.AspNetCore.Identity;

namespace SIMS.Data
{
    public class UserSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


            string[] roles = { "Admin", "Lecture", "Student" };


            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            string adminEmail = "admin@admin.com";
            string adminPassword = "123";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var User = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Name = "System Administrator",
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(User, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(User, "Admin");
                }
            }
        }
    }
}