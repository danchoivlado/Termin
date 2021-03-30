using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Data.Repositories
{
    public class RoleRepository
    {
        private RoleManager<IdentityRole> RoleManager { get; set; }

        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            this.RoleManager = roleManager;
        }

        public async Task<List<IdentityRole>> GetAllRolesAsync()
        {
            return await RoleManager.Roles.ToListAsync();
        }
    }
}
