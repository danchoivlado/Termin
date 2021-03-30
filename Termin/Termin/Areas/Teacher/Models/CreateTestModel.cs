using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Termin.Areas.Teacher.Models
{
    public class CreateTestModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int Grade3 { get; set; }

        [Required]
        public int Grade4 { get; set; }

        [Required]
        public int Grade5 { get; set; }

        [Required]
        public int Grade6 { get; set; }

        public ClaimsPrincipal UserPrincible { get; set; }

    }
}
