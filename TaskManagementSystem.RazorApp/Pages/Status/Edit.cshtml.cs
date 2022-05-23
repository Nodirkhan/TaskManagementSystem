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
    public class EditModel : PageModel
    {
        private readonly ITaskStatusItemService _statusService;
        public TaskStatusItemDTO Status { get; set; }
        public EditModel(ITaskStatusItemService statusService)
        {
            _statusService = statusService;
        }
        public async Task OnGetAsync(int id)
        {
            Status = await _statusService.GetTaskStatus(id);
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (ModelState.IsValid)
            {
                var statusToUpdate = await _statusService.GetTaskStatus(id);
                if(statusToUpdate is not null)
                {
                    if (await TryUpdateModelAsync(
                        statusToUpdate,
                        "Status",
                        e => e.Name
                        ))
                    {
                        await _statusService.UpdateAsync(statusToUpdate);
                    }
                return RedirectToPage("ListStatsus");
                }
            }
            return Page();
        }
    }
}
