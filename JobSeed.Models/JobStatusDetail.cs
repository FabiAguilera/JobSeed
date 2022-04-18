using JobSeed.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobSeed.Data.JobStatus;

namespace JobSeed.Models
{
    public class JobStatusDetail
    {
        public int StatusId { get; set; }
        public StatusType Status { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUTc { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Job Job { get; set; }

    }
}
