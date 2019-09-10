using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTasks.Models
{
    public enum JobStatus { Active, Done, Failed };
    public class Job
    {
        public Job()
        {
            JobTag = new List<JobTag>();
        }
        public ICollection<JobTag> JobTag { get; set; }

        public int Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime Deadline { get; set; }
        public JobStatus Status { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

       
    }
}
