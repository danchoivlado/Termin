using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Termin.Areas.Teacher.Models;
using Termin.Data;
using Termin.Data.DataModels;
using Termin.Data.Repositories;
using System.Security.Claims;


namespace Termin.Areas.Teacher.Pages.Tests
{
    public class CreateModel : PageModel
    {
        private readonly TestRepository _testRepository;

        public CreateModel(TestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateTestModel Test { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Test.UserPrincible = this.User;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _testRepository.AddTestAsync(Test);
            return RedirectToPage("./Index");
        }
    }
}
