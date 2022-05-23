using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.TaskItems
{
    [Authorize(Roles =("Admin"))]
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ITaskStatusItemService _statusService;
        private readonly IUserService _userService;
        private readonly ITaskItemService _taskService;
        public TaskItemDTO TaskItemDTO { get; set; }
        public IReadOnlyList<TaskStatusItemDTO> Statuses { get; set; }
        public IReadOnlyList<UserDTO> Users { get; set; }
        public EditModel(
            ITaskItemService taskservice,
            IUserService userService,
            ITaskStatusItemService statusService        
            )
        {
            _statusService = statusService;
            _userService = userService;
            _taskService = taskservice;
        }
        public async Task<IActionResult> OnGetAsync(int Id)
        {
            if (Id < 0) return NotFound();
            Statuses = await _statusService.GetAllAsync();
            Users = await _userService.GetAllAsync();
            TaskItemDTO = await _taskService.GetTaskitem(Id);
            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int Id)
        {
            if (Id < 0) return NotFound();
            var tasktoUpdate = await _taskService.GetTaskitem(Id);
            if (tasktoUpdate == null) return NotFound();

            if (ModelState.IsValid)
            {
                if (!await TryUpdateModelAsync<TaskItemDTO>(
                 tasktoUpdate,
                 "TaskItemDTO",
                 e => e.Name, e => e.EndDate, e => e.UserId, e => e.TaskStatusId, e => e.Description
                 ))
                {
                }
                else
                {
                    await _taskService.UpdateAsync(tasktoUpdate);
                }
                return RedirectToPage("ListTaskItem", new { Id = tasktoUpdate.ProjectId });
            }
            return Page();
        }
    }
}
