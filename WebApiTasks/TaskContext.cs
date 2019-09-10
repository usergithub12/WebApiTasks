using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTasks.Models;

namespace WebApiTasks
{
    public class TaskContext : DbContext
    {



        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
           

        }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTag>()
                .HasKey(t => new { t.JobId, t.TagId });

            modelBuilder.Entity<JobTag>()
                .HasOne(sc => sc.Job)
                .WithMany(s => s.JobTag)
                .HasForeignKey(sc => sc.JobId);

            modelBuilder.Entity<JobTag>()
                .HasOne(sc => sc.Tag)
                .WithMany(c => c.JobTags)
                .HasForeignKey(sc => sc.TagId);
        }


        public DbSet<Job> Jobs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<JobTag> JobTags { get; set; }
    }
}

