using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.Login
{
    [BindProperties]
    public class AuthorizationModel : PageModel
    {
        private readonly IUserService _service;
        public LoginModel LoginModel { get; set; }
        public AuthorizationModel(IUserService service)
        {
            _service = service;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _service.LoginAsync(LoginModel.UserName, LoginModel.Password);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.GivenName, user.FirstName),
                        new Claim(ClaimTypes.Name,user.FirstName),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    };
                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                    return RedirectToPage("/Index");
                }
            }
            return Page();
        }
    }
}
