using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Models
{
    public class TakeTestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<QuestionModel> Questions { get; set; }
    }
}
