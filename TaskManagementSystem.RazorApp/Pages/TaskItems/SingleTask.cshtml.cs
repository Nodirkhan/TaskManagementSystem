using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.TaskItems
{
    [BindProperties]
    public class SingleTaskModel : PageModel
    {


        private readonly ITaskStatusItemService _statusService;
        private readonly IUserService _userService;
        private readonly ITaskItemService _taskService;
        public TaskItemDTO TaskItemDTO { get; set; }
        public TaskStatusItemDTO Status { get; set; }
        public UserDTO User { get; set; }
        public SingleTaskModel(
            ITaskItemService taskservice,
            IUserService userService,
            ITaskStatusItemService statusService
            )
        {
            _statusService = statusService;
            _userService = userService;
            _taskService = taskservice;
        }
        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id < 0) return NotFound();
            TaskItemDTO = await _taskService.GetTaskitem(Id);
            if (TaskItemDTO == null) return NotFound();
            Status = await _statusService.GetTaskStatus(TaskItemDTO.TaskStatusId);
            User = await _userService.GetUser(TaskItemDTO.UserId);
            return Page();
        }

    } 
}
