using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Entities
{
    public class TaskStatusItem : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<TaskItem> Tasks { get; set; }
    }
}
