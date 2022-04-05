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
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(new Job
                {
                    Position = model.Position,
                    Company = model.Company,
                    URL = model.URL,
                    Salary = model.Salary,
                    Location = model.Location,
                    UserId = _userId,
                    CreatedUtc = DateTimeOffset.Now
                });

                if (ctx.Jobs.SaveChanges() = 1)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
