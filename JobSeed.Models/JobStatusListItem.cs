using JobSeed.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JobSeed.Data.JobStatus;

namespace JobSeed.Models
{
    public class JobStatusListItem
    {
        public int StatusId { get; set; }
        public StatusType Status { get; set; }

        [Display(Name = "Job Status Established")]
        public DateTimeOffset CreatedUtc { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Job Job { get; set; }
    }
}
