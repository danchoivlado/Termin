using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Termin.Models;

namespace Termin.Pages
{
    public class TestsModel : PageModel
    {
        public string Acctive { get; set; }
        public string Passed { get; set; }
        public string Current { get; set; }
        [BindProperty]
        public SearchInput InputSearch { get; set; }


        public void OnGet()
        {
            
        }

        public void OnPostFilterForm()
        {
            
        }
    }
}
