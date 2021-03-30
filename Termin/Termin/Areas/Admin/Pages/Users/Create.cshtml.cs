using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Termin.Areas.Admin.Models;
using Termin.Data.Repositories;
using Termin.Models;

namespace Termin.Areas.Admin.Pages.Users
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateUserModel UserModel { get; set; }
        private readonly RoleRepository roleRepository;
        private readonly UserRepository userRepository;

        public CreateModel(RoleRepository roleRepository, UserRepository userRepository)
        {
            this.roleRepository = roleRepository;
            this.userRepository = userRepository;
        }

        public async Task OnGet()
        {
            ViewData["RoleName"] = new SelectList(await this.roleRepository.GetAllRolesAsync(), "Name", "Name");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var applicationUser = new ApplicationUser()
            {
                Email = this.UserModel.Email,
                FirstName = this.UserModel.FirstName,
                MiddleName = this.UserModel.MiddleName,
                LasName = this.UserModel.LasName,
                LockoutEnabled = this.UserModel.LockoutEnabled,
                UserName = this.UserModel.UserName,
                PhoneNumber = this.UserModel.PhoneNumber,
                PhoneNumberConfirmed = this.UserModel.PhoneNumberConfirmed,
                TwoFactorEnabled = this.UserModel.TwoFactorEnabled,
            };

            await this.userRepository
                .AddUserAsync(applicationUser, this.UserModel.Password, this.UserModel.RoleName);

            return RedirectToPage("./Index");
        }
    }
}
