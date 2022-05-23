using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.TaskItems
{
    [Authorize]
    [BindProperties]
    public class ListTaskItemModel : PageModel
    {
        private readonly ITaskStatusItemService _statusService;
        private  readonly IProjectService _projectService;
        public ProjectDTO Project { get; set; }
        public IReadOnlyList<TaskItemDTO> TaskItems; 
        public IReadOnlyList<UserDTO> Users; 
        public IReadOnlyList<TaskStatusItemDTO> Statuses;
        public ListTaskItemModel(ITaskItemService taskservice, 
            IProjectService projectservice,
            ITaskStatusItemService statusService,
            IUserService userService) 
        {
            _statusService = statusService;
            _projectService = projectservice;
        }
        public async Task<IActionResult> OnGet(int id)
        {

            if (id < 0) return NotFound();
            Project = await _projectService.JoinTaskItemAsync(id);
            if (Project is not null)
            {
                 TaskItems = Project.Tasks;
                return Page();
            }
            return NotFound();
        }
    }
}
