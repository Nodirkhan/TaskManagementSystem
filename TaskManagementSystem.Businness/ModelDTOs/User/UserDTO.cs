using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Businness.ModelDTOs
{
    public class UserDTO : UserModel
    {
        public int Id { get; set; }

        public IReadOnlyList<ProjectDTO> Projects { get; set; }

        public IReadOnlyList<TaskItemDTO> TaskItems { get; set; }
    }
}
