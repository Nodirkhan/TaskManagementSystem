using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.User
{
    [Authorize(Roles =("Admin"))]
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;
        public UserModel UserModel { get; set; }

        public CreateModel(IUserService userservice)
        {
            _userService = userservice;
        }
        
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var User = await _userService.CreateAsync(UserModel);
                if (User == null) return Page();
                return RedirectToPage("ListUser");
            }
            return Page();
        }
    }
}
