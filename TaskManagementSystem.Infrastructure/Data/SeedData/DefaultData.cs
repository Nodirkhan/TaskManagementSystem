using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Infrastructure.Data.SeedData
{
    public class DefaultData : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "Boss",
                    UserName = "admin",
                    Password = "admin",
                    Role = EnumRole.Admin,
                    CreatedDate = DateTime.Now
                },
                new User
                {
                    Id = 2,
                    FirstName = "Employee",
                    LastName = "Employee",
                    UserName = "user",
                    Password = "user",
                    Role = EnumRole.Employee,
                    CreatedDate = DateTime.Now
                }
                );
        }
        

    }
}
