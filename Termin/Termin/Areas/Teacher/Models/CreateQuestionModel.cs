using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Areas.Teacher.Models
{
    public class CreateQuestionModel
    {
        [Required]
        [Display(Name = "Name", ResourceType = typeof(Resources.Areas.Teacher.Pages.Shared._AddQuestionPartial))]
        public string Name { get; set; }

        [Required]
        [Display(Name = "FirstOption", ResourceType = typeof(Resources.Areas.Teacher.Pages.Shared._AddQuestionPartial))]
        public string FirstOption { get; set; }

        [Required]
        [Display(Name = "SecondOption", ResourceType = typeof(Resources.Areas.Teacher.Pages.Shared._AddQuestionPartial))]
        public string SecondOption { get; set; }

        [Required]
        [Display(Name = "ThirdOption", ResourceType = typeof(Resources.Areas.Teacher.Pages.Shared._AddQuestionPartial))]
        public string ThirdOption { get; set; }

        [Required]
        [Display(Name = "ForthOption", ResourceType = typeof(Resources.Areas.Teacher.Pages.Shared._AddQuestionPartial))]
        public string ForthOption { get; set; }

        public int TestId { get; set; }

        [Required]
        public string RighAnswer { get; set; }

        public string PreviousRighAnswer { get; set; }

        public int QuestionId { get; set; }

        [Required]
        [Display(Name = "Points", ResourceType = typeof(Resources.Areas.Teacher.Pages.Shared._AddQuestionPartial))]
        public int Points { get; set; }

    }
}
