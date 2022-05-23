using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Businness.ModelDTOs
{
    public class TaskStatusItemDTO : TaskStatusItemModel
    {
        [Required]
        public int Id { get; set; }
        public IReadOnlyList<TaskItemDTO> Tasks { get; set; }

    }
}
