using System.ComponentModel.DataAnnotations;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Businness.ModelDTOs
{
    public class UserModel
    {
        [Required]
        [StringLength(60)]
        [DataType(DataType.Text)]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(60)]
        [DataType(DataType.Text)]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }
        [Required]
        [StringLength(60)]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]   
        [Display(Name = "Please confirm password")]
        [Compare("Password", ErrorMessage ="Password is not valid. PLease enter same Password!")]
        public string ComparePassWord { get; set; }
        [Required]
        public EnumRole Role { get; set; }
    }
}
