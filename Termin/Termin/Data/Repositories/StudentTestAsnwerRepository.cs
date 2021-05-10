using Microsoft.EntityFrameworkCore;
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
            this.dbContext.Questions.Load();
        }

        public void ProcessAnswers(Dictionary<int, int> questionAndAnswersIds, StudentTest studentTest)
        {
            //First we have to add to database studentTest and the we have to add StudentTestAsnwer
            this.dbContext.StudentTests.Add(studentTest);
            this.dbContext.SaveChanges();
            var studentTestId = studentTest.Id;


            foreach (var questionAnswerId in questionAndAnswersIds)
            {
                var questionId = questionAnswerId.Key;
                var answerId = questionAnswerId.Value;

                var answer = this.dbContext.Answers.FirstOrDefault(x => x.Id == answerId);

                StudentTestAsnwer student = new StudentTestAsnwer()
                {
                    QuestionId = questionAnswerId.Key,
                    AnswerId = questionAnswerId.Value,
                    StudentTestId = studentTestId,
                };

                if (answer.IsRightAnswer)
                {
                    student.GainedAnswers = answer.Question.Points;
                }

                this.dbContext.StudentTestAsnwers.Add(student);
            }

            this.dbContext.SaveChanges();
        }
    }
}
