using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Entities;
using TaskManagementSystem.Infrastructure.Data;
using TaskManagementSystem.Infrastructure.Interfaces;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class TaskStatusItemRepository : BaseRepositoryAsync<TaskStatusItem>, ITaskStatusItemRepository
    {
        private DbSet<TaskStatusItem> _statuses;
        private DbSet<TaskItem> _tasks;
        private ITaskItemRepository _taskRepository;

        public TaskStatusItemRepository(ApplicationDbContext context,ITaskItemRepository taskRepository) : base(context)
        {
            _statuses = context.TaskStatuseItems;
            _tasks = context.TaskItems;
            _taskRepository = taskRepository;
        }

    }
}
