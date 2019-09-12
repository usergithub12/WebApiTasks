using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiTasks.Models;

namespace WebApiTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly JobsContext db;

        public CategoryController(JobsContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }
        
    }
}