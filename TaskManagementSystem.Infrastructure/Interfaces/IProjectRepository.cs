using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Infrastructure.Interfaces
{
    public interface IProjectRepository : IBaseRepositoryAsync<Project>
    {
        Task<IReadOnlyList<Project>> JoinProject(int Id);
    }
}
