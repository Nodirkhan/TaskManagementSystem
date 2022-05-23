using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.User
{
    [Authorize(Roles =("Admin,Employee"))]
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;
        public UserDTO UserDTO { get; set; }
        public bool AgreementToChooseRole { get; set; }

        public EditModel(IUserService userservice)
        {
            _userService = userservice;
        }
        public async Task OnGet(int Id)
        {
            UserDTO = await _userService.GetUser(Id);
        }
        public async Task<IActionResult> OnPost(int Id)
        {
            AgreementToChooseRole = User.FindFirstValue(ClaimTypes.Role) == "Admin" ? true : false;
            if (Id < 0) return NotFound();
            if (ModelState.IsValid)
            {

             var userToUpdate = await _userService.GetUser(Id);
             if (userToUpdate == null) return NotFound();
              if (await TryUpdateModelAsync<UserDTO>(
                userToUpdate,
                "UserDTO",
                e => e.FirstName, e => e.LastName, e => e.UserName, e => e.Password, e => e.Role
                ))
              {
                await _userService.UpdateAsync(userToUpdate);
                
              }
                return RedirectToPage("ListUser");
            }
            return Page();
        }
    }
}
