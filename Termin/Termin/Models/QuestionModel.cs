using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public string QuestionName { get; set; }

        public List<AnswersModel> Answers { get; set; }  
    }
}
