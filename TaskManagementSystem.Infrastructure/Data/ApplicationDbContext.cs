using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Entities;
using TaskManagementSystem.Infrastructure.Data.SeedData;

namespace TaskManagementSystem.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskStatusItem> TaskStatuseItems { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Project> Projects { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DefaultData());
            builder.ApplyConfiguration(new DefaultStatus());
        }
    }
}
