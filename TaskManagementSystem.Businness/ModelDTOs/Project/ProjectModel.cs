using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Businness.ModelDTOs
{
    public class ProjectModel
    {
        [Required]
        [StringLength(60)]
        [DataType(DataType.Text)]
        [Display(Name = "Project Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name ="Created date")]
        public DateTime CreatedDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

    }
}
