using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Termin.Models;

namespace Termin.Pages
{
    public class TestsModel : PageModel
    {
        [BindProperty]
        public SearchInput InputSearch { get; set; }

        private UserManager<ApplicationUser> userManager;

        public TestsModel(UserManager<ApplicationUser> userManager)
        {
            this.InputSearch = new SearchInput();
            this.userManager = userManager;
        }

        public void OnGet()
        {

        }

        public void OnPostFilterForm()
        {
            var userId = this.userManager.GetUserId(this.User);
        }
    }
}
