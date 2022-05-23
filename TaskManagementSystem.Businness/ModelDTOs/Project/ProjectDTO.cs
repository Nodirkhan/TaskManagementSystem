using System.Collections.Generic;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Businness.ModelDTOs
{
    public class ProjectDTO : ProjectModel
    {
        public int Id { get; set; } 
        public IReadOnlyList<TaskItemDTO> Tasks { get; set; }
    
    }
}
