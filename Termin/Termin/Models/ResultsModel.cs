using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Termin.Models
{
    public class ResultsModel
    {
        public int Points { get; set; }

        public DateTime Started { get; set; }

        public DateTime Ended { get; set; }

        public int Grade { get; set; }
    }
}
