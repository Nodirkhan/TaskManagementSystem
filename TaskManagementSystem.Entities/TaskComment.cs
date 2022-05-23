using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Entities
{
    public class TaskComment : BaseEntity
    {
        [Required]
        public string Comment { get; set; }

        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
    }
}
