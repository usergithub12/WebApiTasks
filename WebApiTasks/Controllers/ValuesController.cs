using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTasks.Models;

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
            return db.Jobs.Include(s => s.Category).Include(v => v.JobTag).ToList();
        }
    }
}
