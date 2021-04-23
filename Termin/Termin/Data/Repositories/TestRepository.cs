using AutoMapper;
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

        public List<TestModel> GetDataFromSearch(bool active, bool past, bool future, string userId)
        {
            //only for active tests
            var user = this.context.ApplicationUsers.First(x => x.Id == userId);
            var date = DateTime.Now;
            var activeTest = this.context.Tests.Where(x => x.Start <= date && x.End >= date).Select(x => mapper.Map<TestModel>(x)).ToList();
            return activeTest;
        }
    }
}
