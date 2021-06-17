using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Areas.Teacher.Models
{
    public class IndexTestModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name", ResourceType = typeof(Resources.Areas.Teacher.Pages.Tests.Index))]
        public string Name { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.Areas.Teacher.Pages.Tests.Index))]
        public string Description { get; set; }

        public int TestId { get; set; }
    }
}
