using JobSeed.Data;
using JobSeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeed.Services
{
    public class DocumentService
    {
        private readonly string _userId;

        public DocumentService(string userId)
        {
            _userId = userId;
        }

        public IEnumerable<DocumentListItem> GetDocs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
               ctx.Documents
                    .Select(d => new DocumentListItem
                    {
                        DocumentId = d.DocumentId,
                        DocumentType = d.DocumentType,
                        DocumentAdded = d.DocumentAdded
                    });
                return query.ToArray();
            }
        }

        public bool CreateDocument(DocumentCreate model)
        {
            var entity = new Document()
            {
                DocumentType = model.DocumentType,
                DocumentAdded = model.DocumentAdded,
                DocSubmitted = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Documents.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public DocumentDetail GetDocumentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Documents
                    .Single(e => e.DocumentId == id && e.UserId == _userId);
                return
                    new DocumentDetail
                    {
                        DocumentId = entity.DocumentId,
                        DocumentType = entity.DocumentType,
                        DocSubmitted = entity.DocSubmitted,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateDocument (DocumentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Documents
                    .Single(e => e.DocumentId == model.DocumentId && e.UserId == _userId);

                entity.DocumentAdded = model.DocumentAdded;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDocument(int documentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Documents
                    .Single(e => e.DocumentId == documentId && e.UserId == _userId);

                ctx.Documents.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
