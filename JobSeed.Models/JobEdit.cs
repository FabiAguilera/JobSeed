using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeed.Models
{
    public class JobEdit
    {
        public int JobId { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public string URL { get; set; }

        public decimal Salary { get; set; }

        public string Location { get; set; }
    }
}
