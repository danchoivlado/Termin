using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Areas.Admin.Models
{
    public class CreateUserModel
    {
        public string Id { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Resources.Areas.Admin.Pages.Users.Create.TheEmailFieldIsRequired),
            ErrorMessageResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        public string Email { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Resources.Areas.Admin.Pages.Users.Create.TheFirstNameFieldIsRequired),
            ErrorMessageResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Resources.Areas.Admin.Pages.Users.Create.TheMiddleNameFieldIsRequired),
            ErrorMessageResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        [Display(Name = "MiddleName", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        [StringLength(20, MinimumLength = 2)]
        public string MiddleName { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Resources.Areas.Admin.Pages.Users.Create.TheLastNameFieldIsRequired_),
            ErrorMessageResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        [Display(Name = "LastName", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        [StringLength(20, MinimumLength = 2)]
        public string LasName { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Resources.Areas.Admin.Pages.Users.Create.ThePasswordFieldIsRequired),
            ErrorMessageResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //[Required(
        //    ErrorMessageResourceName = nameof(Resources.Areas.Admin.Pages.Users.Create.),
        //    ErrorMessageResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        [Display(Name = "LockoutEnabled", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        public bool LockoutEnabled { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Resources.Areas.Admin.Pages.Users.Create.TheUserNameFieldIsRequired),
            ErrorMessageResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        [Display(Name = "UserName", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        public string UserName { get; set; }

        [Required(
            ErrorMessageResourceName = nameof(Resources.Areas.Admin.Pages.Users.Create.ThePhoneNumberFieldIsRequired),
            ErrorMessageResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        [Phone]
        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "PhoneNumberConfirmed", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        public bool PhoneNumberConfirmed { get; set; }

        [Required]
        [Display(Name = "TwoFactorEnabled", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        public bool TwoFactorEnabled { get; set; }

        [Display(Name = "RoleName", ResourceType = typeof(Resources.Areas.Admin.Pages.Users.Create))]
        public string RoleName { get; set; }
    }
}
