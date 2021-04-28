using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Termin.Areas.Teacher.Models;
using Termin.Data.DataModels;
using Termin.Utility;

namespace Termin.Data.Repositories
{
    public class QuestionRepository
    {
        public ApplicationDbContext dbContext { get; set; }

        public QuestionRepository(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
            this.dbContext.Answers.Load();
        }

        public async Task AddQuestionToTestAsync(CreateQuestionModel createQuestionModel)
        {
            var question = new Question()
            {
                QuestionName = createQuestionModel.Name,
                TestId = createQuestionModel.TestId,
                QuestionType = QuestionTypes.MultipleChoiceQuestions,
            };

            this.dbContext.Questions.Add(question);
            await this.dbContext.SaveChangesAsync();

            var questionId = question.Id;


            var answer1 = new Answer() 
            { 
                Name=createQuestionModel.FirstOption,
                QuestionId = questionId, 
                IsRightAnswer = createQuestionModel.RighAnswer == "1" ? true : false
            };

            var answer2 = new Answer()
            {
                Name = createQuestionModel.SecondOption,
                QuestionId = questionId,
                IsRightAnswer = createQuestionModel.RighAnswer == "2" ? true : false
            };

            var answer3 = new Answer()
            {
                Name = createQuestionModel.ThirdOption,
                QuestionId = questionId,
                IsRightAnswer = createQuestionModel.RighAnswer == "3" ? true : false
            };

            var answer4 = new Answer()
            {
                Name = createQuestionModel.ForthOption,
                QuestionId = questionId,
                IsRightAnswer = createQuestionModel.RighAnswer == "4" ? true : false
            };

            this.dbContext.Answers.Add(answer1);
            this.dbContext.Answers.Add(answer2);
            this.dbContext.Answers.Add(answer3);
            this.dbContext.Answers.Add(answer4);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditQuestionToTestAsync(CreateQuestionModel createQuestionModel)
        {
            var question = this.dbContext.Questions.First(x => x.Id == createQuestionModel.QuestionId);
            question.QuestionName = createQuestionModel.Name;
            question.Answers.ToArray()[0].Name = createQuestionModel.FirstOption;
            question.Answers.ToArray()[1].Name = createQuestionModel.SecondOption;
            question.Answers.ToArray()[2].Name = createQuestionModel.ThirdOption;
            question.Answers.ToArray()[3].Name = createQuestionModel.ForthOption;

            question.Answers.ToArray()[int.Parse(createQuestionModel.PreviousRighAnswer)-1].IsRightAnswer =  false;
            question.Answers.ToArray()[int.Parse(createQuestionModel.RighAnswer) - 1].IsRightAnswer = true;

            await this.dbContext.SaveChangesAsync();
        }

        public List<QuestionIndexModel> GetAllQuestionsFromTestWithId(int id)
        {
            var lis = new List<QuestionIndexModel>();

            foreach (var question in this.dbContext.Questions.Where(x => x.TestId == id))
            {
                var curQuestion = new QuestionIndexModel()
                {
                    Id = question.Id,
                    Name = question.QuestionName,
                };

                lis.Add(curQuestion);
            }

            return lis;
        }

        public async Task DeleteQuestionOfTestWithIdAsync (int qustionId, int testId)
        {
            var question = await this.dbContext.Questions.FirstOrDefaultAsync
                (x => x.Id == qustionId && x.TestId == testId);
            if (question == null)
            {
                return;
            }

            this.dbContext.Questions.Remove(question);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<CreateQuestionModel> GetQuestionWithIdAsync(int questionId)
        {
            var question = await this.dbContext.Questions.FirstOrDefaultAsync(x => x.Id == questionId);

            if (question == null)
            {
                return null;
            }
            var answers = question.Answers.ToArray();
            var rightAnswerNumber = -1;
            for (int i = 1; i < 5; i++)
            {
                if (answers[i-1].IsRightAnswer)
                {
                    rightAnswerNumber = i;
                }
            }
            var questionModel = new CreateQuestionModel()
            {
                Name = question.QuestionName,
                FirstOption = answers[0].Name,
                SecondOption = answers[1].Name,
                ThirdOption = answers[2].Name,
                ForthOption = answers[3].Name,
                RighAnswer = rightAnswerNumber.ToString(),
            };

            return questionModel;
        }
    }
}
