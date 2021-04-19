using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Termin.Areas.Teacher.Models;
using Termin.Data.Repositories;

namespace Termin.Areas.Teacher.Pages.Tests
{
    public class QuestionsModel : PageModel
    {
        public TestRepository testRepository;
        public QuestionRepository questionRepository;

        public QuestionsModel(TestRepository testRepository, QuestionRepository questionRepository)
        {
            this.testRepository = testRepository;
            this.questionModel = new CreateQuestionModel();
            this.questionRepository = questionRepository;
        }

        [BindProperty]
        public CreateQuestionModel questionModel { get; set; }
        private static int TestId;

        public IActionResult OnGet(int id)
        {
            if (!this.testRepository.HasTestWithId(id))
            {
                return NotFound();
            }

            TestId = id;

            return Page();
        }

        public PartialViewResult OnGetQuestionModal()
        {
            return Partial("_AddQuestionPartial", new CreateQuestionModel() { TestId = TestId});
        }

        public async Task<PartialViewResult> OnGetQuestionModalEdit(int id)
        {
            var model = await this.questionRepository.GetQuestionWithIdAsync(id);
            model.TestId = TestId;
            model.QuestionId = id;
            model.PreviousRighAnswer = model.RighAnswer;
            return Partial("_EditQuestionPartial", model);
        }

        public async Task<PartialViewResult> OnPostQuestionModal()
        {
            if (ModelState.IsValid)
            {
                await this.questionRepository.AddQuestionToTestAsync(this.questionModel);
            }

            return Partial("_AddQuestionPartial", new CreateQuestionModel() { TestId = TestId });
        }

        public async Task<PartialViewResult> OnPostQuestionModalEdit()
        {
            if (ModelState.IsValid)
            {
                await this.questionRepository.EditQuestionToTestAsync(this.questionModel);
            }

            return Partial("_AddQuestionPartial", new CreateQuestionModel() { TestId = TestId });
        }

        public PartialViewResult OnGetAllContacts()
        {
            return Partial("_AllContactsPartial", questionRepository.GetAllQuestionsFromTestWithId(TestId));
        }

        public async Task<IActionResult> OnGetDeleteQuestion(int id)
        {
            await this.questionRepository.DeleteQuestionOfTestWithIdAsync(id, TestId);
            return RedirectToPage("Questions",new { id = TestId });
        }
    }
}
