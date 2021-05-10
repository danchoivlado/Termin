using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Data.DataModels
{
    public class StudentTestAsnwer
    {
        public int Id { get; set; }

        [Required]
        public int QuestionId { get; set; } // Not associated with virtual Collection

        public virtual Question Question { get; set; }

        [Required]
        public int AnswerId { get; set; }// Not associated with virtual Collection

        public virtual Answer Answer { get; set; }

        [Required]
        public int StudentTestId { get; set; }

        public virtual StudentTest StudentTest { get; set; }

        public int GainedAnswers { get; set; }
    }
}
