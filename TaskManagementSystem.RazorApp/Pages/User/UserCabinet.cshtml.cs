using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.User
{
    [Authorize]
    [BindProperties]
    public class UserCabinetModel : PageModel
    {
        private readonly IUserService _userService;
        public UserDTO UserDTO { get; set; }

        public UserCabinetModel(IUserService userservice)
        {
            _userService = userservice;
        }
        public async Task<IActionResult> OnGet(int Id)
        {
            if(Id<0) return NotFound();
            UserDTO = await _userService.GetUser(Id);
            if(UserDTO == null) return NotFound();
            return Page();
        }
    }
}
