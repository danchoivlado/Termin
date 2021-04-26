using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Termin.Data.DataModels;
using Termin.Models;

namespace Termin.AutoMapperProfiles
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateMap<Test, TestModel>();
            CreateMap<Question, QuestionModel>();
            CreateMap<Answer, AnswersModel>();
        }
    }
}


//.ForMember(vm => vm.UserName, m => m.MapFrom(u => (u.UserName != null)
//                                                   ? u.UserName
//                                                   : "User" + u.ID.ToString()));