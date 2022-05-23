using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.Businness.Interfaces
{
    public interface ITaskStatusItemService
    {
        Task<IReadOnlyList<TaskStatusItemDTO>> JoinAsyncListTaskItem(int Id);
        Task<TaskStatusItemDTO> JoinAsyncTaskItem(int Id);
        Task<IReadOnlyList<TaskStatusItemDTO>> GetPageListAsync(int page, int pageSize);
        Task<TaskStatusItemDTO> GetTaskStatus(int id);
        Task<IReadOnlyList<TaskStatusItemDTO>> GetAllAsync();
        Task<TaskStatusItemDTO> CreateAsync(TaskStatusItemModel taskStatusItemModel);
        Task UpdateAsync(TaskStatusItemDTO taskStatusItemDTO);
        Task DeleteAsync(int Id);

    }
}
