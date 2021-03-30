using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Termin.Areas.Admin.Models;
using Termin.Data.Repositories;
using Termin.Models;

namespace Termin.Areas.Admin.Pages.Users
{
    public class IndexModel : PageModel
    {
        public List<IndexUserModel> Users { get; set; }
        private  UserRepository userRepository { get; set; }

        public IndexModel(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task OnGetAsync()
        {
            var repositoryUsers = await userRepository.GetAllUsersAsync();
            this.Users = repositoryUsers.Select(x => new IndexUserModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LasName,
                Email = x.Email
            }).ToList();
        }
    }
}
