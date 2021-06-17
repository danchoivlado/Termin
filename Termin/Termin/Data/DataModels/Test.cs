using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Termin.Models;

namespace Termin.Data.DataModels
{
    public class Test
    {
        public Test()
        {
            this.Questions = new HashSet<Question>();
            this.StudentTests = new HashSet<StudentTest>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Name",ResourceType = typeof(Resources.Areas.Teacher.Pages.Tests.Edit))]
        public string Name { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.Areas.Teacher.Pages.Tests.Edit))]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start", ResourceType = typeof(Resources.Areas.Teacher.Pages.Tests.Edit))]
        public DateTime Start { get; set; }

        [Required]
        [Display(Name = "End", ResourceType = typeof(Resources.Areas.Teacher.Pages.Tests.Edit))]
        public DateTime End { get; set; }

        [Required]
        [Display(Name = "Duration", ResourceType = typeof(Resources.Areas.Teacher.Pages.Tests.Edit))]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "Grade3", ResourceType = typeof(Resources.Areas.Teacher.Pages.Tests.Edit))]
        public int Grade3 { get; set; }

        [Required]
        [Display(Name = "Grade4", ResourceType = typeof(Resources.Areas.Teacher.Pages.Tests.Edit))]
        public int Grade4 { get; set; }

        [Required]
        [Display(Name = "Grade5", ResourceType = typeof(Resources.Areas.Teacher.Pages.Tests.Edit))]
        public int Grade5 { get; set; }

        [Required]
        [Display(Name = "Grade6", ResourceType = typeof(Resources.Areas.Teacher.Pages.Tests.Edit))]
        public int Grade6 { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<StudentTest> StudentTests { get; set; }
    }
}
