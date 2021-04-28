using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Termin.Data.Repositories;

namespace Termin.Pages
{
    public class TakeTestModel : PageModel
    {
        private TestRepository TestRepository;

        public TakeTestModel(TestRepository testRepository)
        {
            this.TestRepository = testRepository;
        }

        [BindProperty]
        public Termin.Models.TakeTestModel Take { get; set; }

        public IActionResult OnGet(int id)
        {
            if (!TestRepository.ValidateTest(id))
            {
                return NotFound();
            }

            this.Take = TestRepository.GetTestWithQuestions(id);

            return Page();
        }

        public IActionResult OnPost(IFormCollection keyValuePairs)
        {
            foreach (var question in keyValuePairs)
            {
                Console.WriteLine(question);
            }

            return RedirectToPage("/Tests");
        }
    }
}
