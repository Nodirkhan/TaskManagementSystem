using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Entities;
using TaskManagementSystem.Infrastructure.Data;
using TaskManagementSystem.Infrastructure.Interfaces;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class TaskItemRepository : BaseRepositoryAsync<TaskItem>, ITaskItemRepository
    {
        private DbSet<TaskItem> _taskItems;
        private DbSet<User> _users;
        private DbSet<Project> _projects;
        private DbSet<TaskStatusItem> _taskStatus;

        public TaskItemRepository(ApplicationDbContext context) : base(context)
        {
            _taskItems = context.TaskItems;
            _users = context.Users;
            _projects = context.Projects;
            _taskStatus = context.TaskStatuseItems;

        }

        public async Task<IReadOnlyList<TaskItem>> JoinTaskAsyncToUser(int Id)
        {
            IReadOnlyList<TaskItem> tasks = await (from user in _users
                                                    join task in _taskItems
                                                    on user.Id equals task.UserId
                                                    where user.Id == Id
                                                    select task).ToListAsync();
            return tasks;
        }
        public async Task<IReadOnlyList<TaskItem>> JoinTaskAsyncToProject(int Id)
        {
            IReadOnlyList<TaskItem> tasks = await (from project in _projects
                                                   join task in _taskItems
                                                   on project.Id equals task.ProjectId
                                                   where project.Id == Id
                                                   select task).ToListAsync();
            return tasks;
        }
      
        public async Task<IReadOnlyList<TaskItem>> JoinTaskAsyncToStatus(int Id)
        {
            IReadOnlyList<TaskItem> tasks = await  (from status in _taskStatus
                                                  join task in _taskItems
                                                  on status.Id equals task.TaskStatusId
                                                  where status.Id == Id
                                                  select task).ToListAsync();
            return tasks;
        }
    }
}