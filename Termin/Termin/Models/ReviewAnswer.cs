using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Models
{
    public class ReviewAnswer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsRightAnswer { get; set; }

        public bool IsThisAnswerChoosenByStudent { get; set; }
    }
}
