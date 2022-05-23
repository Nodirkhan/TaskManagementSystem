using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.Businness.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDTO> JoinTaskItemAsync(int Id);
        Task<IReadOnlyList<ProjectDTO>> GetPageListAsync(int page, int pageSize);
        Task<ProjectDTO> GetProject(int id);
        Task<IReadOnlyList<ProjectDTO>> GetAllAsync();
        Task<ProjectDTO> CreateAsync(ProjectModel projectModel);
        Task UpdateAsync(ProjectDTO project);
        Task DeleteAsync(int Id);

    }
}
