using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [Display(Name = "Superhero", ResourceType = typeof(Resources.Pages.Index))]
        [Required(
            ErrorMessageResourceName = nameof(Resources.Pages.Index.SuperHeroFieldIsRequired),
            ErrorMessageResourceType = typeof(Resources.Pages.Index))]
        public string Superhero { get; set; }

        public void OnGet()
        {

        }
    }
}
