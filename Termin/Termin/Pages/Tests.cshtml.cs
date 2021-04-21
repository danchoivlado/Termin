using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Termin.Pages
{
    public class TestsModel : PageModel
    {
        public string Acctive { get; set; }
        public string Passed { get; set; }
        public string Current { get; set; }
        [BindProperty]
        public string Name { get; set; }


        public void OnGet()
        {
            
        }

        public void OnPostFilterForm()
        {
            ;
        }
    }
}
