using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Termin.Areas.Teacher.Models;
using Termin.Data.DataModels;
using Termin.Models;

namespace Termin.Data.Repositories
{
    public class TestRepository
    {
        private readonly ApplicationDbContext context;
        private UserRepository userRepository;
        private readonly IMapper mapper;

        public TestRepository(ApplicationDbContext context, UserRepository userRepository, IMapper mapper)
        {
            this.context = context;
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.context.Questions.Load();
            this.context.Answers.Load();
            this.context.StudentTestAsnwers.Load();
        }

        public async Task AddTestAsync(CreateTestModel createTestModel)
        {
            var user = await this.userRepository.GetUser(createTestModel.UserPrincible);

            var test = new Test()
            {
                Name = createTestModel.Name,
                Description = createTestModel.Description,
                Start = createTestModel.Start,
                End = createTestModel.End,
                Duration = createTestModel.Duration,
                Grade3 = createTestModel.Grade3,
                Grade4 = createTestModel.Grade4,
                Grade5 = createTestModel.Grade5,
                Grade6 = createTestModel.Grade6,
                User = user,
            };

            this.context.Tests.Add(test);
            await this.context.SaveChangesAsync();
        }

        public List<IndexTestModel> GetAllTests()
        {
            var testList = new List<IndexTestModel>();
            foreach (var test in this.context.Tests)
            {
                var curTest = new IndexTestModel()
                {
                    Description = test.Description,
                    Id = test.Id,
                    Name = test.Name,
                };

                testList.Add(curTest);
            }

            return testList;
        }

        public bool HasTestWithId(int id)
        {
            return this.context.Tests.Any(x => x.Id == id);
        }

        public List<TestModel> GetDataFromSearch(bool active, bool past, bool future, string userId, string filterValue)
        {
            //only for active tests
            var user = this.context.ApplicationUsers.First(x => x.Id == userId);
            var date = DateTime.Now;
            var activeTests = new List<TestModel>();
            var passedTests = new List<TestModel>();
            var futureTests = new List<TestModel>();

            if (active == true)
            {
                activeTests = this.context.Tests.Where(x => x.Start <= date && x.End >= date && x.Name.Contains(filterValue))
                    .Select(x => new TestModel() { Id = x.Id, Name = x.Name, Active = true }).ToList();
            }

            if (past == true)
            {
                passedTests = this.context.StudentTests.Where(x => x.UserId == userId && x.Test.Name.Contains(filterValue))
                    .Select(x => new TestModel() { Id = x.Test.Id, Name = x.Test.Name }).ToList();
            }

            if (future == true)
            {
                futureTests = this.context.Tests.Where(x => x.Start > date && x.Name.Contains(filterValue)).Select(x => mapper.Map<TestModel>(x)).ToList();
            }

            return activeTests.Union(passedTests).Union(futureTests).ToList();
        }

        public bool ValidateTest(int testId, string userid)
        {
            var date = DateTime.Now;
            var currentTest = this.context.Tests.FirstOrDefault(x => x.Id == testId);

            if (this.context.StudentTests.Any(x => x.UserId == userid && x.TestId == testId && x.Ended != null))
            {
                return false;
            }
            
            if(currentTest == null)
            {
                return false;
            }

            if (currentTest.Start > date && currentTest.End > date)
            {
                return false;
            }

            return true;
        }

        public TakeTestModel GetTestWithQuestions(int testId)
        {
            var currTest = this.context.Tests.First(x => x.Id == testId);
            var test = new TakeTestModel()
            {
                Id = currTest.Id,
                Name = currTest.Name,
                Questions = currTest.Questions.Select(x => mapper.Map<QuestionModel>(x)).ToList(),
            };

            return test;
        }

        public ResultsModel GetResultsForTest(int testId, string userId) 
        {
            var test = this.context.Tests.FirstOrDefault(x => x.Id == testId);
            var studentTest = this.context.StudentTests.FirstOrDefault(x => x.UserId == userId && x.Id == testId);
            var result = new ResultsModel()
            {
                Started = studentTest.Started,
                Ended = studentTest.Ended,
            };

            var points = studentTest.StudentTestAsnwers.Sum(x => x.GainedAnswers);
            result.Points = points;


            if (points < test.Grade3)
            {
                result.Grade = 2;
            }
            else if (points < test.Grade4)
            {
                result.Grade = 3;
            }
            else if (points < test.Grade5)
            {
                result.Grade = 4;
            }
            else if (points < test.Grade6)
            {
                result.Grade = 5;
            }
            else
                result.Grade = 6;

            return result;
        }
    }
}
