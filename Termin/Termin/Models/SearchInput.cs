using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Models
{
    public class SearchInput
    {
        public string FilterValue { get; set; }

        public bool Active { get; set; }

        public bool Passed { get; set; }

        public bool Future { get; set; }

        public SearchInput()
        {
            this.Active = true;
            this.Future = true;
        }
    }
}
