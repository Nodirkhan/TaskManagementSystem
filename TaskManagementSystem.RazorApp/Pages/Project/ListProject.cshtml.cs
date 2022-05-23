using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.RazorApp.Pages.Project
{
    [Authorize]
    [BindProperties]
    public class ListProjectModel : PageModel
    {
        private readonly IProjectService _service;
        public IReadOnlyList<ProjectDTO> Projects { get; set; }
        public ListProjectModel(IProjectService service)
        {
            _service = service;
        }
        public async Task OnGet()
        {
            Projects = await _service.GetAllAsync();
        }
    }
}
