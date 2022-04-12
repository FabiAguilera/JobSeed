using JobSeed.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeed.Models
{
    public class DocumentDetail
    {
        public int DocumentId { get; set; }

        public string DocumentType { get; set; }

        public bool DocumentAdded { get; set; }

        public DateTimeOffset DocSubmitted { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
