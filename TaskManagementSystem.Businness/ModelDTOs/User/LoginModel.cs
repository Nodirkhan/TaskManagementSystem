using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Businness.ModelDTOs
{
    public class LoginModel
    {
        [Required]
        [Display(Name ="Username")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
