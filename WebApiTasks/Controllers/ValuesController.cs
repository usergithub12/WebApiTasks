using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTasks.Models;
using WebApiTasks.ViewModels;

namespace WebApiTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly JobsContext db;

        public ValuesController(JobsContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IEnumerable<Job> GetJobs()
        {
            return db.Jobs.Include(s => s.Category).ToList();
        }

        [HttpPost("Add")]
        public bool AddJobs([FromForm] JobsVM model)
        {
            var category = db.Categories.FirstOrDefault(c => c.Name == model.Category) ?? new Category { Name = model.Category };
            var job =  new Job
            {
                Category = category,
                Deadline = DateTime.Parse(model.Deadline),
                Priority = model.Priority,
                Status = (JobStatus)model.Status,
                Description = model.Description,
            };
            db.Jobs.Add(job);
            db.SaveChanges();
            return true;
        }

        [HttpPost("Delete")]
        public bool Delete(int id)
        {
            var job = db.Jobs.Find(id);
            if(job!=null)
            {
                db.Jobs.Remove(job);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
           
        }
        [HttpPost("Edit")]
        public bool Edit([FromForm] JobsVM model)
        {
            var category = db.Categories.FirstOrDefault(c => c.Name == model.Category) ?? new Category { Name = model.Category };
            var job = db.Jobs.Find(model.Id);
            job.Category = category;
            job.Deadline = DateTime.Parse(model.Deadline);
            job.Priority = model.Priority;
            job.Status = (JobStatus)model.Status;
            job.Description = model.Description;
            db.SaveChanges();

            return true;
        }



    }

}
