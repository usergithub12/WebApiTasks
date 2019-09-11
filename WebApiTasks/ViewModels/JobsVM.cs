using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTasks.Models;

namespace WebApiTasks.ViewModels
{
    public class JobsVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string Deadline { get; set; }
        public int Status { get; set; }
        public string Category { get; set; }
    }
}
