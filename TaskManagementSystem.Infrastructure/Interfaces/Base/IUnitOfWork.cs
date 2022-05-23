using System.Threading.Tasks;

namespace TaskManagementSystem.Infrastructure.Interfaces
{
    public interface IUnitOfWork 
    {
        IUserRepositoryAsync UserRepository { get; }
        IProjectRepository ProjectRepository{ get; }
        ITaskItemRepository TaskItemRepository{ get; }
        ITaskStatusItemRepository TaskStatusItemRepository{ get; }
        Task SaveAsync();
        void Dispose();
    }
}
