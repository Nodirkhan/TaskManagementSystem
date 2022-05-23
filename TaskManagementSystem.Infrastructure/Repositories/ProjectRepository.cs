using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Entities;
using TaskManagementSystem.Infrastructure.Data;
using TaskManagementSystem.Infrastructure.Interfaces;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class ProjectRepository : BaseRepositoryAsync<Project>, IProjectRepository
    {

        private readonly DbSet<Project> _projects;
        private readonly DbSet<User> _users;
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
            _users = context.Users;
            _projects = context.Projects;
        }

        public async Task<IReadOnlyList<Project>> JoinProject(int Id)
        {
            IReadOnlyList<Project> projects = await (from user in _users
                                            join project in _projects
                                            on user.Id equals project.UserId
                                            where user.Id == Id
                                            select project).ToListAsync();
            return projects;
        }

    }
}
