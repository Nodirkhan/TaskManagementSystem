using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Businness.ModelDTOs
{
    public class TaskStatusItemModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
