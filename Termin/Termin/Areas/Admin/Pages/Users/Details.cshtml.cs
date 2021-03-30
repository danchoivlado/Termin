using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Termin.Areas.Admin.Models;
using Termin.Data;
using Termin.Data.Repositories;

namespace Termin.Areas.Admin.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly Termin.Data.ApplicationDbContext _context;
        private UserRepository userRepository;

        public DetailsModel(Termin.Data.ApplicationDbContext context, UserRepository userRepository)
        {
            _context = context;
            this.userRepository = userRepository;
        }

        public CreateUserModel CreateUserModel { get; set; }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await userRepository.GetUserByIdAsync(id);

            this.CreateUserModel = new CreateUserModel()
            {
                Email = applicationUser.Email,
                FirstName = applicationUser.FirstName,
                MiddleName = applicationUser.MiddleName,
                LasName = applicationUser.LasName,
                Id = applicationUser.Id,
                LockoutEnabled = applicationUser.LockoutEnabled,
                PhoneNumber = applicationUser.PhoneNumber,
                PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed,
                UserName = applicationUser.UserName,
            };

            if (CreateUserModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
