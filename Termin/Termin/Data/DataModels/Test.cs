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
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public DateTime Duration { get; set; }

        [Required]
        public int Grade3 { get; set; }

        [Required]
        public int Grade4 { get; set; }

        [Required]
        public int Grade5 { get; set; }

        [Required]
        public int Grade6 { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<StudentTest> StudentTests { get; set; }
    }
}
