using Microsoft.AspNetCore.Identity;

namespace GymManagement.Services
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Tạo Roles
            string[] roleNames = { "Admin", "Staff" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Tạo Admin
            var adminEmail = "admin@gymmanagement.com";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new IdentityUser { UserName = "admin", Email = adminEmail, EmailConfirmed = true };
                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            // Tạo Staff
            var staffEmail = "staff@gymmanagement.com";
            if (await userManager.FindByEmailAsync(staffEmail) == null)
            {
                var staff = new IdentityUser { UserName = "staff", Email = staffEmail, EmailConfirmed = true };
                await userManager.CreateAsync(staff, "Staff@123");
                await userManager.AddToRoleAsync(staff, "Staff");
            }
        }
    }
}