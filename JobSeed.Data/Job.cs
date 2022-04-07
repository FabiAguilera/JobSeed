using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeed.Data
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public string UserId { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public ICollection<Document> Documents { get; set; }
    }
}
