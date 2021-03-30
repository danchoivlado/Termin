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
        public string Email { get; set; }

        [Display(Name ="First name")]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name ="Middle name")]
        [StringLength(20, MinimumLength = 2)]
        public string MiddleName { get; set; }

        [Display(Name ="Last name")]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }
    }
}
