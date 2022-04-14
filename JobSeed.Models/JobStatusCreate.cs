using JobSeed.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobSeed.Data.JobStatus;

namespace JobSeed.Models
{
    public class JobStatusCreate
    {
        public StatusType Status { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual Job Job { get; set; }

    }
}
