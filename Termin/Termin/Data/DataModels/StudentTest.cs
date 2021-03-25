using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Termin.Models;

namespace Termin.Data.DataModels
{
    public class StudentTest
    {
        public StudentTest()
        {
            this.StudentTestAsnwers = new HashSet<StudentTestAsnwer>();
        }

        public int Id { get; set; }

        [Required]
        public DateTime Started { get; set; }

        [Required]
        public DateTime Ended { get; set; }

        [Required]
        public int TestId { get; set; }

        public virtual Test Test { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<StudentTestAsnwer> StudentTestAsnwers { get; set; }
    }
}
