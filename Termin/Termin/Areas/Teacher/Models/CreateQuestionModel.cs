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
        public string Name { get; set; }

        [Required]
        public string FirstOption { get; set; }
        [Required]
        public string SecondOption { get; set; }

        [Required]
        public string ThirdOption { get; set; }

        [Required]
        public string ForthOption { get; set; }

        public int TestId { get; set; }

        [Required]
        public string RighAnswer { get; set; }

        public string PreviousRighAnswer { get; set; }

        public int QuestionId { get; set; }
    }
}
