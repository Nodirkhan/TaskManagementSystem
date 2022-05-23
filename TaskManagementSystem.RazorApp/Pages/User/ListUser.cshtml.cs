using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.User
{
    [Authorize]
    [BindProperties]
    public class ListUserModel : PageModel
    {
        private readonly IUserService _userService;
        public IReadOnlyList<UserDTO> Users { get; set; }
        public ListUserModel(IUserService userservice)
        {
            _userService = userservice;
        }
        public async Task OnGet()
        {
            Users = await _userService.GetAllAsync();
        }
    }
}
