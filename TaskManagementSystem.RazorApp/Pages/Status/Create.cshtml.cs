using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.Status
{
    [Authorize(Roles =("Admin"))]
    [BindProperties]
    public class CreateModel : PageModel
    {
           private readonly ITaskStatusItemService _statusService;
           public TaskStatusItemDTO Status { get; set; }
           public CreateModel(ITaskStatusItemService statusService)
           {
            _statusService = statusService;
           }
           public async Task<IActionResult> OnPostAsync()
           {
            if (ModelState.IsValid)
            {
                await _statusService.CreateAsync(Status);
                return RedirectToPage("ListStatus");
            }
            return Page();
           }
        
    }
}
