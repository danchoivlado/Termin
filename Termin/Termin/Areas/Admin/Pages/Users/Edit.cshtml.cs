using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Termin.Areas.Admin.Models;
using Termin.Data;
using Termin.Data.Repositories;

namespace Termin.Areas.Admin.Pages.Users
{
    public class EditModel : PageModel
    {
        private UserRepository userRepository;

        public EditModel(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [BindProperty]
        public EditUserModel EditUserModel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await this.userRepository.GetUserByIdAsync(id);

            if (applicationUser == null)
            {
                return NotFound();
            }

            this.EditUserModel = new EditUserModel()
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
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
             {
                return Page();
            }

            var applicationUser = await this.userRepository.GetUserByIdAsync(EditUserModel.Id);

            applicationUser.Id = EditUserModel.Id;
            applicationUser.Email = EditUserModel.Email;
            applicationUser.FirstName = EditUserModel.FirstName;
            applicationUser.MiddleName = EditUserModel.MiddleName;
            applicationUser.LasName = EditUserModel.LasName;
            applicationUser.LockoutEnabled = EditUserModel.LockoutEnabled;
            applicationUser.PhoneNumber = EditUserModel.PhoneNumber;
            applicationUser.PhoneNumberConfirmed = EditUserModel.PhoneNumberConfirmed;
            applicationUser.UserName = EditUserModel.UserName;
            await this.userRepository.UpdateUserAsync(applicationUser);

            return RedirectToPage("Index");
        }
    }
}
