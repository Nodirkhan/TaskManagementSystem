using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.ModelDTOs;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Businness.Interfaces
{
    public interface ITaskItemService
    {
        Task<IReadOnlyList<TaskItemDTO>> GetPageListAsync(int page, int pageSize);
        Task<TaskItemDTO> GetTaskitem(int id);
        Task<IReadOnlyList<TaskItemDTO>> GetAllAsync();
        Task<TaskItemDTO> CreateAsync(TaskItemModel taskItemModel);
        Task UpdateAsync(TaskItemDTO taskItemDTO);
        Task DeleteAsync(int Id);

    }
}
