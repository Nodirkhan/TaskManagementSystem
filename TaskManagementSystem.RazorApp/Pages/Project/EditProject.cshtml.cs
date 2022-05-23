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
    public class EditProjectModel : PageModel
    {
        private readonly IProjectService _service;
        public ProjectDTO ProjectDTO { get; set; }
        public EditProjectModel(IProjectService service)
        {
            _service = service;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if(id <0)
            {
                return NotFound();
            }
            ProjectDTO = await _service.GetProject(id);
            if(ProjectDTO == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int Id)
        {
            var projectToUpdate = await _service.GetProject(Id); 
            if(projectToUpdate is null)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
            if(await TryUpdateModelAsync<ProjectDTO>(
                projectToUpdate,
                "ProjectDTO",
                e=>e.Name,e=>e.EndDate
                ))
                {
                    await _service.UpdateAsync(projectToUpdate);
                    return RedirectToPage("ListProject");
                }
                return RedirectToPage("ListProject");
                    
            }
            return Page();
        }
    }
}
