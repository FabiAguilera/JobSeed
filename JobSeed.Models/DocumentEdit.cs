using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeed.Models
{
    public class DocumentEdit
    {
        public int DocumentId { get; set; }
        public string DocumentType { get; set; }
        public bool DocumentAdded { get; set; }
    }
}
