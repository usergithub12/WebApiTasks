using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTasks.Models
{
    public class JobTag
    {
        public int JobId { get; set; }
        public Job Job { get; set; }

        public int TagId { get; set; }
        public Tag  Tag { get; set; }
    }
}
