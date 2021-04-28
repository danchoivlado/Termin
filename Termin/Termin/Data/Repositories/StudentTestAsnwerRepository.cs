using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Termin.Data.DataModels;

namespace Termin.Data.Repositories
{
    public class StudentTestAsnwerRepository
    {
        private readonly ApplicationDbContext dbContext;

        public StudentTestAsnwerRepository(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }

        public void ProcessAnswers(Dictionary<int, int> questionAndAnswersIds, StudentTest studentTest)
        {
            //First we have to add to database studentTest and the we have to add StudentTestAsnwer


            foreach (var questionAnswerId in questionAndAnswersIds)
            {
            //    StudentTestAsnwer student = new StudentTestAsnwer()
            //    {
            //        QuestionId =  questionAnswerId.Key,
            //        AnswerId = questionAnswerId.Value,
            //        stude
            //    }
            }

        }
    }
}
