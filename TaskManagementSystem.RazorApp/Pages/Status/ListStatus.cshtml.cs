using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.NewFolder
{
    [Authorize]
    [BindProperties]
    public class ListStatusModel : PageModel
    {
        private readonly ITaskStatusItemService _statusService;
        public IReadOnlyList<TaskStatusItemDTO> Statuses { get; set; }
        public ListStatusModel(ITaskStatusItemService statusService)
        {
            _statusService = statusService;
        }
        public async Task OnGet()
        {
            Statuses = await _statusService.GetAllAsync();
        }
    }
}
