using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Termin.Models;
using System.Security.Claims;

namespace Termin.Data.Repositories
{
    public class UserRepository
    {
        private UserManager<ApplicationUser> userManager { get; set; }
        private ApplicationDbContext applicationDb;

        public UserRepository(UserManager<ApplicationUser> userManager,
            ApplicationDbContext applicationDbContext)
        {
            this.userManager = userManager;
            this.applicationDb = applicationDbContext;
        }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await this.userManager.Users.ToListAsync();
        }

        public async Task AddUserAsync(ApplicationUser user, string password, string roleName)
        {
            await userManager.CreateAsync(user, password);
            if (string.IsNullOrEmpty(roleName))
            {
                await this.applicationDb.SaveChangesAsync();
                return;
            }

            await userManager.AddToRoleAsync(user, roleName);
            await this.applicationDb.SaveChangesAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string id)
        {
            return await this.userManager.FindByIdAsync(id);
        }

        public async Task UpdateUserAsync(ApplicationUser applicationUser)
        {
            this.applicationDb.Attach(applicationUser).State = EntityState.Modified;
            await this.applicationDb.SaveChangesAsync();
        }

        public string GetUserId(ClaimsPrincipal claimsPrincipal)
        {
            return this.userManager.GetUserId(claimsPrincipal);
        }

        public async Task<ApplicationUser> GetUser(ClaimsPrincipal claimsPrincipal)
        {
            return await this.userManager.GetUserAsync(claimsPrincipal);
        }
    }
}
