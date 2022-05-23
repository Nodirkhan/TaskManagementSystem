using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<TaskItem> Tasks { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
