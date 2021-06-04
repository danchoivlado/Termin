using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Models
{
    public class ReviewQuestion
    {
        public int Id { get; set; }
            
        public string QuestionName { get; set; }

        public int Points { get; set; }

        public List<ReviewAnswer> Answers { get; set; }
    }
}
