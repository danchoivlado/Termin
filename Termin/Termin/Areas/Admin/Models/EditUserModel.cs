using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Areas.Admin.Models
{
    public class EditUserModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Middle name")]
        [StringLength(20, MinimumLength = 2)]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(20, MinimumLength = 2)]
        public string LasName { get; set; }


        [Required]
        [Display(Name = "Lockout Enabled")]
        public bool LockoutEnabled { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Phone Number Confirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [Required]
        [Display(Name = "Two Factor Enabled")]
        public bool TwoFactorEnabled { get; set; }

        public string RoleName { get; set; }
    }
}
