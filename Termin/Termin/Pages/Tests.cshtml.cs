using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Termin.Data.Repositories;
using Termin.Models;

namespace Termin.Pages
{
    public class TestsModel : PageModel
    {
        [BindProperty]
        public SearchInput InputSearch { get; set; }

        private UserManager<ApplicationUser> userManager;
        private TestRepository testRepository;

        public TestsModel(UserManager<ApplicationUser> userManager, TestRepository testRepository)
        {
            this.InputSearch = new SearchInput();
            this.userManager = userManager;
            this.testRepository = testRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnGetPartial(bool c1, bool c2, bool c3, string filterValue)
        {
            var userId = this.userManager.GetUserId(this.User);
            var data = this.testRepository.GetDataFromSearch(c1, c2, c3, userId, filterValue == null ? string.Empty: filterValue);

            return new PartialViewResult
            {
                ViewName = "_TestsPartial",
                ViewData = new ViewDataDictionary<List<TestModel>>(ViewData, data)
            };
        }

        public async Task<PartialViewResult> OnGetResultsAsync(int id)
        {
            var userId = this.userManager.GetUserId(this.User);

            return Partial("_ResultsPartial", testRepository.GetResultsForTest(id, userId));
        }

    }
}
