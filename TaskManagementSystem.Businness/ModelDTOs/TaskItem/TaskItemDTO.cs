using System.ComponentModel.DataAnnotations;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Businness.ModelDTOs
{
    public class TaskItemDTO : TaskItemModel
    {
        [Required]
        public int Id { get; set; }
      
    }
}
