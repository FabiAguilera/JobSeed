using JobSeed.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeed.Models
{
    public class DocumentCreate
    {
        [MaxLength(100, ErrorMessage = "There are too many characters in this field")]
        public string DocumentType { get; set; }

        public bool DocumentAdded { get; set; }

        public virtual int JobId { get; set; }
        public virtual ICollection<int?> Jobs { get; set; }
    }
}
