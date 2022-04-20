using JobSeed.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeed.Models
{
    public class JobCreate
    {
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field")]
        public string Position { get; set; }

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field")]
        public string Company { get; set; }

        public string URL { get; set; }

        public decimal Salary { get; set; }

        public string Location { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<int?> DocumentId { get; set; }

        public virtual JobStatus Status { get; set; }

    }
}
