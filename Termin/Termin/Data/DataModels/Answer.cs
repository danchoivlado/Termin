using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Data.DataModels
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsRightAnswer { get; set; }

        [Required]
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
