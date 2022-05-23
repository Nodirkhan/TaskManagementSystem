using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Infrastructure.Interfaces
{
    public interface ITaskItemRepository : IBaseRepositoryAsync<TaskItem>  
    {
        Task<IReadOnlyList<TaskItem>> JoinTaskAsyncToUser(int Id);
        Task<IReadOnlyList<TaskItem>> JoinTaskAsyncToProject(int Id);
        Task<IReadOnlyList<TaskItem>> JoinTaskAsyncToStatus(int Id);

    }

}
