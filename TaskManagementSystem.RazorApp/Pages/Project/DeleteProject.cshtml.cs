using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.Project
{
    [Authorize(Roles =("Admin"))]
    [BindProperties]
    public class DeleteProjectModel : PageModel
    {
        private readonly IProjectService _projectservice;
        private readonly ITaskItemService _taskservice;
        public ProjectDTO ProjectDTO { get; set; } 
        public DeleteProjectModel(IProjectService service,ITaskItemService taskservice)
        {
            _projectservice = service;
            _taskservice = taskservice;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            ProjectDTO = await  _projectservice.JoinTaskItemAsync(id);
            if(ProjectDTO is null)
            {
                return RedirectToPage("ListProject");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int Id)
        {
            if (Id < 0)
            {
                return NotFound();
            }
            if(ProjectDTO.Tasks is not null)
            {
                foreach(var task in ProjectDTO.Tasks)
                {
                await _taskservice.DeleteAsync(task.Id);
                }
            }
            await _projectservice.DeleteAsync(Id);
            return RedirectToPage("ListProject");
            
        }
    }
}
