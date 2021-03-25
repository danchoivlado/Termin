using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Termin.Utility;

namespace Termin.Data.DataModels
{
    public class Question
    {
        public Question()
        {
            this.Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        [Required]
        public string QuestionName { get; set; }

        [Required]
        public QuestionTypes QuestionType { get; set; }

        [Required]
        public int TestId { get; set; }

        public virtual Test Test { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
