using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Infrastructure.Data.SeedData
{
    public class DefaultStatus : IEntityTypeConfiguration<TaskStatusItem>
    {
        public void Configure(EntityTypeBuilder<TaskStatusItem> builder)
        {
            builder.HasData(new TaskStatusItem
            {
                Id = 1,
                Name = "ToDo",
                CreatedDate = DateTime.Now,
                Tasks = null,
            },
            new TaskStatusItem
            {
                Id = 2,
                Name = "InProgress",
                CreatedDate = DateTime.Now,
                Tasks = null,
            },
            new TaskStatusItem
            {
                Id = 3,
                Name = "InTesting",
                CreatedDate = DateTime.Now,
                Tasks = null,
            },
            new TaskStatusItem
            {
                Id = 4,
                Name = "Done",
                CreatedDate = DateTime.Now,
                Tasks = null,
            }
            );
        }
    }
}
