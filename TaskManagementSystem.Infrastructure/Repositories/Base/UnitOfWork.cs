using System;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.Data;
using TaskManagementSystem.Infrastructure.Interfaces;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public IUserRepositoryAsync UserRepository { get; set; }

        public IProjectRepository ProjectRepository { get; set; }

        public ITaskItemRepository TaskItemRepository { get; set; }

        public ITaskStatusItemRepository TaskStatusItemRepository { get; set; }

        public UnitOfWork(ApplicationDbContext context,
            IUserRepositoryAsync userRepository,
            IProjectRepository projectRepository,
            ITaskItemRepository taskItemRepository,
            ITaskStatusItemRepository taskStatusItemRepository
            )
        {
            _context = context;
            UserRepository = userRepository;
            ProjectRepository = projectRepository;
            TaskItemRepository = taskItemRepository;
            TaskStatusItemRepository = taskStatusItemRepository;
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
