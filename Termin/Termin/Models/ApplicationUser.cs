using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string name) : base(name)
        {
        }

        public ApplicationUser()
        {

        }

        [Required]
        [Display(Name = "First name")]
        [StringLength(20,MinimumLength =2)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Middle name")]
        [StringLength(20,MinimumLength =2)]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name ="Last name")]
        [StringLength(20,MinimumLength =2)]
        public string LasName { get; set; }
    }
}
