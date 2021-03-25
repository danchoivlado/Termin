using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Termin.Data;
using Termin.Data.DataModels;

namespace Termin.Areas.Teacher.Pages.Tests
{
    public class IndexModel : PageModel
    {
        private readonly Termin.Data.ApplicationDbContext _context;

        public IndexModel(Termin.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Test> Test { get;set; }

        public async Task OnGetAsync()
        {
            Test = await _context.Tests
                .Include(t => t.User).ToListAsync();
        }
    }
}
