using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Termin.Data.DataModels;
using Termin.Data.Repositories;
using Termin.Models;

namespace Termin.Pages
{
    public class TakeTestModel : PageModel
    {
        private TestRepository TestRepository;
        private StudentTestAsnwerRepository studentRep;
        private static StudentTest studentTest = new StudentTest();
        private UserManager<ApplicationUser> userManager;

        public TakeTestModel(TestRepository testRepository, StudentTestAsnwerRepository studentRep, UserManager<ApplicationUser> userManager)
        {
            this.TestRepository = testRepository;
            this.studentRep = studentRep;
            this.userManager = userManager;
        }

        [BindProperty]
        public Termin.Models.TakeTestModel Take { get; set; }

        public IActionResult OnGet(int id)
        {
            var userId = this.userManager.GetUserId(this.User);

            if (!TestRepository.ValidateTest(id, userId))
            {
                return LocalRedirect("/Identity/Account/AccessDenied");
            }

            this.Take = TestRepository.GetTestWithQuestions(id);
            studentTest.TestId = id;
            studentTest.Started = DateTime.Now;
            studentTest.UserId = userId;

            return Page();
        }

        public IActionResult OnPost(IFormCollection keyValuePairs)
        {
            var dictionary = keyValuePairs.Take(keyValuePairs.Count-1).ToDictionary(t => int.Parse(t.Key), t => int.Parse(t.Value.First()));
            studentTest.Ended = DateTime.Now;

            this.studentRep.ProcessAnswers(dictionary, studentTest);

            return RedirectToPage("/Tests");
        }
    }
}
