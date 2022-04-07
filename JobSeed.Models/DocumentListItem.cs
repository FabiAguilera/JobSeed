using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeed.Models
{
    public class DocumentListItem
    {
        public int DocumentId { get; set; }

        public string DocumentType { get; set; }

        public bool DocumentAdded { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset DocSubmitted { get; set; }
    }
}
