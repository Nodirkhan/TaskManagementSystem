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
    public class CreateModel : PageModel
    {
        private readonly ITaskStatusItemService _statusService;
        private readonly IUserService _userService;
        private readonly ITaskItemService _taskService;
        public TaskItemModel TaskModel{ get; set; }
        public int ID { get; set; }
        public IReadOnlyList<TaskStatusItemDTO> Statuses { get; set; }
        public IReadOnlyList<UserDTO> Users { get; set; }
        public CreateModel(
            ITaskItemService taskservice,
            IUserService userService,
            ITaskStatusItemService statusService) 
        {
            _statusService = statusService;
            _userService = userService;
            _taskService = taskservice;
        }
        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id < 0) return NotFound();
            Statuses = await _statusService.GetAllAsync();
            Users = await _userService.GetAllAsync();
            ID = Id;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int Id)
        {
            if(Id < 0) return NotFound();
            TaskModel.CreatedDate = DateTime.Now;
            TaskModel.ProjectId = Id;
            if (ModelState.IsValid)
            {
               var task = await _taskService.CreateAsync(TaskModel);
                if(task is null)
                {
                    return NotFound();
                }
            return RedirectToPage("ListTaskItem", new {Id = Id});
            }
            return Page();
        }
    }
}
