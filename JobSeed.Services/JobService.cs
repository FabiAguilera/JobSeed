using JobSeed.Data;
using JobSeed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeed.Services
{
    public class JobService
    {
        private readonly string _userId;

        public JobService(string userId)
        {
            _userId = userId;
        }

        public IEnumerable<JobListItem> GetJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Jobs
                    .Select(j => new JobListItem
                    {
                        JobId = j.JobId,
                        Position = j.Position,
                        Company = j.Company,
                        URL = j.URL,
                        Salary = j.Salary,
                        Location = j.Location
                    });
                return query.ToArray();
            }
        }
        public bool CreateJob(JobCreate model)
        {
            var entity = new Job()
                {
                    Position = model.Position,
                    Company = model.Company,
                    URL = model.URL,
                    Salary = model.Salary,
                    Location = model.Location,
                    UserId = _userId,
                    CreatedUtc = DateTimeOffset.Now
                };

                using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public JobDetail GetJobById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Jobs
                    .Single(e => e.JobId == id && e.UserId == _userId);
                return
                    new JobDetail
                    {
                        JobId = entity.JobId,
                        Position = entity.Position,
                        Company = entity.Company,
                        URL = entity.URL,
                        Salary = entity.Salary,
                        Location = entity.Location,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateJob (JobEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Jobs
                    .Single(e => e.JobId == model.JobId && e.UserId == _userId);

                entity.Position = model.Position;
                entity.Company = model.Company;
                entity.URL = model.URL;
                entity.Salary = model.Salary;
                entity.Location = model.Location;
                    entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteJob(int jobId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Jobs
                    .Single(e => e.JobId == jobId && e.UserId == _userId);

                ctx.Jobs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
