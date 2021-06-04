using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Termin.Data.Repositories;
using Termin.Models;

namespace Termin.Pages
{
    public class ReviewTestModel : PageModel
    {
        private UserManager<ApplicationUser> userManager;
        private TestRepository testRepository;

        public ReviewTestModel(UserManager<ApplicationUser> userManager, TestRepository testRepository)
        {
            this.userManager = userManager;
            this.testRepository = testRepository;
        }

        public Models.ReviewTestModel Take { get; set; }

        public void OnGet(int testId)
        {
            var userId = this.userManager.GetUserId(this.User);

            this.Take = this.testRepository.ReviewTest(testId, userId);
        }
    }
}
