using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTasks.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public ICollection<Job> Jobs { get; set; }
    }
}
