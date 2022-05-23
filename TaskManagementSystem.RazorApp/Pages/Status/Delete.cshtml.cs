using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.Status
{
    [Authorize(Roles =("Admin"))]
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ITaskStatusItemService _statusService;
        public TaskStatusItemDTO Status { get; set; }
        public DeleteModel(ITaskStatusItemService statusService)
        {
            _statusService = statusService;
        }
        public async Task OnGetAsync(int id)
        {
            Status = await _statusService.GetTaskStatus(id);
        }
        public async Task<IActionResult> OnPostAsync(int Id)
        {
            if (Id < 0) return NotFound();
            await _statusService.DeleteAsync(Id);
            return RedirectToPage("ListStatus");
        }
    }
}
