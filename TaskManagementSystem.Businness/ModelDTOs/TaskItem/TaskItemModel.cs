using System;
using System.ComponentModel.DataAnnotations;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Businness.ModelDTOs
{
    public class TaskItemModel
    {

        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Created date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name="Task Status Id")]
        public int TaskStatusId { get; set; }
        public TaskStatusItemDTO Status { get; set; }

        [Display(Name = "User Id")]
        public int UserId { get; set; }
        public UserDTO UserDTO { get; set; }
        [Required]
        [Display(Name = "Project Id")]
        public int ProjectId { get; set; }
        public ProjectDTO Project { get; set; }
    }
}
