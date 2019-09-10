using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTasks.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<JobTag> JobTags { get; set; }

        public Tag()
        {
            JobTags = new List<JobTag>();
        }

        public ICollection<Job> Jobs { get; set; }
    }
}
