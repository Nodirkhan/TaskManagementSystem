using System;

namespace TaskManagementSystem.Entities
{
    public class BaseEntity 
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
