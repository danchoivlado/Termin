using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Termin.Areas.Teacher.Models;
using Termin.Data;
using Termin.Data.DataModels;
using Termin.Data.Repositories;

namespace Termin.Areas.Teacher.Pages.Tests
{
    public class IndexModel : PageModel
    {
        private readonly TestRepository _testRepo;

        public IndexModel(TestRepository testRepo)
        {
            this._testRepo = testRepo;
        }

        public IList<IndexTestModel> TestList { get;set; }

        public async Task OnGetAsync()
        {
            this.TestList = this._testRepo.GetAllTests();
        }
    }
}
