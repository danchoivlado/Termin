using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Models
{
    public class ReviewTestModel
    {
        public int TestId { get; set; }

        public string TestName { get; set; }

        public List<ReviewQuestion> Questions { get; set; }
    }
}
