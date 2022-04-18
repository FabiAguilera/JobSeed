using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeed.Data
{
    public class JobStatus
    {
        [ForeignKey("Job")]
        [Key]
        public int StatusId { get; set; }

        public enum StatusType 
        {
            Applied = 1,
            Interviewed,
            Offered,
            Declined,
            Denied
        }

        [Required]
        public StatusType Status { get; set; }

        [Display(Name = "Job Status Established")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Job Status Modified")]
        public DateTimeOffset? ModifiedUTc { get; set; }

       [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        // StatusId has PK and FK in table, JobId as PK column in table
        public virtual Job Job { get; set; }

    }
}
