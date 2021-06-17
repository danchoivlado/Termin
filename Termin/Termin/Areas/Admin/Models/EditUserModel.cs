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

        [Required(
            ErrorMessageResourceName = nameof(Resources.Areas.Admin.Pages.Users.Edit.TheEmailFieldIsRequired),
            ErrorMessageResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        public string Email { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Resources.Areas.Admin.Pages.Users.Edit.TheFirstNameFieldIsRequired),
            ErrorMessageResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Resources.Areas.Admin.Pages.Users.Edit.TheMiddleNameFieldIsRequired),
            ErrorMessageResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        [Display(Name = "MiddleName", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        [StringLength(20, MinimumLength = 2)]
        public string MiddleName { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Resources.Areas.Admin.Pages.Users.Edit.TheLastNameFieldIsRequired_),
            ErrorMessageResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        [Display(Name = "LastName", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        [StringLength(20, MinimumLength = 2)]
        public string LasName { get; set; }


        [Required]
        [Display(Name = "LockoutEnabled", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        public bool LockoutEnabled { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Resources.Areas.Admin.Pages.Users.Edit.TheUserNameFieldIsRequired),
            ErrorMessageResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        [Display(Name = "UserName", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        public string UserName { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Resources.Areas.Admin.Pages.Users.Edit.ThePhoneNumberFieldIsRequired),
            ErrorMessageResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        [Phone]
        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "PhoneNumberConfirmed", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        public bool PhoneNumberConfirmed { get; set; }

        [Required]
        [Display(Name = "TwoFactorEnabled", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        public bool TwoFactorEnabled { get; set; }

        [Display(Name = "RoleName", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Edit))]
        public string RoleName { get; set; }
    }
}
