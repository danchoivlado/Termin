using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Termin.Models;

namespace Termin.Data
{
    public class DbInitializer
    {
        public static async Task InitializeUser(ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            ApplicationUser identityUser = new ApplicationUser("admin@gmail.com")
            {
                Email = "admin@gmail.com",
                FirstName = "admin",
                MiddleName="admin",
                LasName="admin",
            };
            ApplicationUser identityUser2 = new ApplicationUser("teacher@gmail.com")
            {
                Email = "teacher@gmail.com",
                FirstName = "teacher",
                MiddleName = "teacher",
                LasName = "teacher",
            };


            await userManager.CreateAsync(identityUser, "Admin123*");
            await userManager.CreateAsync(identityUser2 , "Admin123*");
            await context.SaveChangesAsync();
        }

        public static async Task InitializeRoles(ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Roles.Any())
            {
                return;   // DB has been seeded
            }

            IdentityRole identityRole = new IdentityRole("Admin");
            IdentityRole identityRole2 = new IdentityRole("Teacher");

            await roleManager.CreateAsync(identityRole);
            await roleManager.CreateAsync(identityRole2);
            await context.SaveChangesAsync();
        }


        public static async Task AssignAdminRole(ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
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
        public static async Task AssignTeacherRole(ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            var teacherUser = await userManager.FindByNameAsync("teacher@gmail.com");
            if (!await roleManager.RoleExistsAsync("Teacher") && teacherUser == null)
            {
                return;   // DB has been seeded
            }

            await userManager.AddToRoleAsync(teacherUser, "Teacher");
            await context.SaveChangesAsync();
        }
    }
}
