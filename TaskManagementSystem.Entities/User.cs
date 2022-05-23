using System.Collections.Generic;

namespace TaskManagementSystem.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public EnumRole Role { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<TaskItem> Tasks { get; set; }
    }
}
