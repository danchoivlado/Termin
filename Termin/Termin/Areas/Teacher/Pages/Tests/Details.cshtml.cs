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
    public class DetailsModel : PageModel
    {
        private readonly Termin.Data.ApplicationDbContext _context;

        public DetailsModel(Termin.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Test Test { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Test = await _context.Tests
                .Include(t => t.User).FirstOrDefaultAsync(m => m.Id == id);

            if (Test == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
