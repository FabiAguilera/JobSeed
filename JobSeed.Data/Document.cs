using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeed.Data
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }

        [Required]
        public string DocumentType { get; set; }
        
        [Required]
        public bool DocumentAdded { get; set; }

        [Required]
        public DateTimeOffset DocSubmitted { get; set; }
       
        public DateTimeOffset? ModifiedUtc { get; set; }

        public string UserId { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
        

    }
}
