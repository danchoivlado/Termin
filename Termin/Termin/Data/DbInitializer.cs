using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Data
{
    public class DbInitializer
    {
        public static async Task InitializeUser(ApplicationDbContext context, 
            UserManager<IdentityUser> userManager)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            IdentityUser identityUser = new IdentityUser("admin@gmail.com");

            await userManager.CreateAsync(identityUser, "Admin123*");
            await context.SaveChangesAsync();
        }

        public static async Task InitializeAdminRole(ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Roles.Any())
            {
                return;   // DB has been seeded
            }

            IdentityRole identityRole = new IdentityRole("Admin");

            await roleManager.CreateAsync(identityRole);
            await context.SaveChangesAsync();
        }

        public static async Task AssignAdminRole(ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            var adminUser = await userManager.FindByNameAsync("admin@gmail.com");
            if (!await roleManager.RoleExistsAsync("Admin") && adminUser == null)
            {
                return;   // DB has been seeded
            }

            await userManager.AddToRoleAsync(adminUser, "Admin");
            await context.SaveChangesAsync();
        }
    }
}
