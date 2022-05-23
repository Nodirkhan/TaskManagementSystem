using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Entities
{
    public class TaskItem : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        
        public int TaskStatusId { get; set; }
        public TaskStatusItem Status { get; set; }


        
        public int UserId { get; set; }
        public User User { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public ICollection<TaskComment> TaskComments { get; set; }
    }
}
