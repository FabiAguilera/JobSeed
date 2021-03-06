using JobSeed.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeed.Models
{
    public class JobListItem
    {
        public int JobId { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public string URL { get; set; }

        public decimal Salary { get; set; }

        public string Location { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<int?> DocumentId { get; set; }
        public virtual JobStatus Status { get; set; }
    }
}
