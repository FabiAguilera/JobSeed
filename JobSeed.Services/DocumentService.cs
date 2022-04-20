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
                        DocumentAdded = d.DocumentAdded,
                        JobId = d.JobId,
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
                DocSubmitted = DateTimeOffset.Now,
                JobId = model.JobId,
            };

            using (var ctx = new ApplicationDbContext())
            {
                //entity.Jobs = new List<Job>();
                //foreach (int id in model.JobId)
                //{
                //    var job = ctx.Jobs.Find(id);
                //    entity.Jobs.Add(job);
                //}
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
                        ModifiedUtc = entity.ModifiedUtc,
                        JobId = entity.JobId
                    };
            }
        }

        public bool UpdateDocument(DocumentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Documents
                    .Single(e => e.DocumentId == model.DocumentId && e.UserId == _userId);

                entity.DocumentType = model.DocumentType;
                entity.DocumentAdded = model.DocumentAdded;
                entity.ModifiedUtc = DateTimeOffset.Now;
                entity.JobId = model.JobId;
                
                //entity.Jobs = new List<Job>();
                //foreach (int id in model.JobId)
                //{
                //    var job = ctx.Jobs.Find(id);
                //    entity.Jobs.Add(job);
                //}
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
