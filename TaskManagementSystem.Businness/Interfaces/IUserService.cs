using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.ModelDTOs;

namespace TaskManagementSystem.Businness.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> JoinProjectAsync(int id);
        Task<UserDTO> JoinTaskItemAsync(int id);
        Task<UserDTO> LoginAsync(string username, string password);
        Task<IReadOnlyList<UserDTO>> GetPageListAsync(int page, int pageSize);
        Task<UserDTO> GetUser(int id);
        Task<IReadOnlyList<UserDTO>> GetAllAsync();
        Task<UserDTO> CreateAsync(UserModel userModel);
        Task UpdateAsync(UserDTO userDTO);
        Task DeleteAsync(int Id);

    }
}
