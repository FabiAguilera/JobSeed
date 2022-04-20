using JobSeed.Data;
using JobSeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeed.Services
{
    public class JobStatusService
    {
        private readonly string _userId;

        public JobStatusService(string userId)
        {
            _userId = userId;
        }

        public IEnumerable<JobStatusListItem> GetStatus()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Status
                    .Select(s => new JobStatusListItem
                    {
                        StatusId = s.StatusId,
                        Status = s.Status,
                        UserId = s.UserId
                    });
                return query.ToArray();
            }
        }

        public bool CreateJobStatus(JobStatusCreate model)
        {
            var entity = new JobStatus()
            {
                Status = model.Status,
                CreatedUtc = DateTimeOffset.Now,
                UserId = model.UserId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Status.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public JobStatusDetail GetStatusById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Status
                    .Single(e => e.StatusId == id && e.UserId == _userId);
                return new JobStatusDetail
                {
                    StatusId = entity.StatusId,
                    Status = entity.Status,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUTc = entity.ModifiedUTc,
                    UserId = entity.UserId
                };
            }
        }

        public bool UpdateStatus(JobStatusEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Status
                    .Single(e => e.StatusId == model.StatusId);

                entity.StatusId = model.StatusId;
                entity.Status = model.Status;
                    entity.ModifiedUTc = DateTimeOffset.Now;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteJobStatus(int statusId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Status
                    .Single(e => e.StatusId == statusId && e.UserId == _userId);

                ctx.Status.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
