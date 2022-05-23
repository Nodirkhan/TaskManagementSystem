using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.User
{
    [Authorize(Roles =("Admin,Employee"))]
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUserService _userService;
        public UserDTO UserDTO { get; set; }

        public DeleteModel(IUserService userservice)
        {
            _userService = userservice;
        }
        public async Task OnGet(int Id)
        {
            UserDTO = await _userService.GetUser(Id);
        }
        public async Task<IActionResult> OnPost(int Id)
        {
            if (Id < 0) return NotFound();
            await _userService.DeleteAsync(Id);
            return RedirectToPage("ListUser");
        }
    }
}
