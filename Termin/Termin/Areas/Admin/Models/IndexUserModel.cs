using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Areas.Admin.Models
{
    public class IndexUserModel
    {
        public string Id { get; set; }

        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Index))]
        public string Email { get; set; }

        [Display(Name ="FirstName", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Index))]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name ="MiddleName", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Index))]
        [StringLength(20, MinimumLength = 2)]
        public string MiddleName { get; set; }

        [Display(Name ="LastName", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Index))]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }
    }
}
