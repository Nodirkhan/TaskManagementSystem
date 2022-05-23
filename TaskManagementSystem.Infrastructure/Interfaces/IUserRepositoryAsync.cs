using System.Threading.Tasks;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Infrastructure.Interfaces
{
    public interface IUserRepositoryAsync : IBaseRepositoryAsync<User>
    {
        Task<User> LoginAsync(string username, string password);
    }
}
