using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Termin.Data;
using Termin.Data.DataModels;

namespace Termin.Areas.Admin.Pages.Tests
{
    public class DeleteModel : PageModel
    {
        private readonly Termin.Data.ApplicationDbContext _context;

        public DeleteModel(Termin.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Test = await _context.Tests.FindAsync(id);

            if (Test != null)
            {
                _context.Tests.Remove(Test);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
