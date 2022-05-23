using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.Project
{

    [Authorize(Roles =("Admin"))]
    [BindProperties]
    public class AddProjectModel : PageModel
    {
        private readonly IProjectService _service;
        public ProjectModel ProjectModel { get; set; }
        public AddProjectModel(IProjectService service)
        {
            _service = service;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                ProjectModel.CreatedDate = DateTime.Now;
                ProjectModel.UserId = 1;
                var project = await _service.CreateAsync(ProjectModel);
                
                if(project != null)
                {
                    return RedirectToPage("ListProject");
                }
            }
            return Page();
        }
    }
}
