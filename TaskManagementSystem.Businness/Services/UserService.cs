using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;
using TaskManagementSystem.Entities;
using TaskManagementSystem.Infrastructure.Interfaces;

namespace TaskManagementSystem.Businness.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserDTO> CreateAsync(UserModel userModel)
        {
           var user = _mapper.Map<User>(userModel);
           await _unitOfWork.UserRepository.CreateAsync(user);
           await _unitOfWork.SaveAsync();

            return _mapper.Map<UserDTO>(user);
        }
        public async Task<IReadOnlyList<UserDTO>> GetAllAsync()
        {
            return _mapper.Map<IReadOnlyList<UserDTO>>(await _unitOfWork.UserRepository.GetAllAsync());
        }

        
        public async Task<IReadOnlyList<UserDTO>> GetPageListAsync(int page, int pageSize)
        {
            return _mapper.Map<IReadOnlyList<UserDTO>>(
                await _unitOfWork.UserRepository.GetPageListAsync(page, pageSize));
        }

        public async Task<UserDTO> GetUser(int id)
        {
            return _mapper.Map<UserDTO>(await _unitOfWork.UserRepository
                .GetByIdAsync(user => user.Id == id, new List<string>())); 
        }

        public async Task DeleteAsync(int Id)
        {
            _unitOfWork.UserRepository.Delete(Id);
            await _unitOfWork.SaveAsync();
        }



        public async Task<UserDTO> JoinProjectAsync(int id)
        {
           
              var projects = _mapper.Map<IReadOnlyList<ProjectDTO>>(await _unitOfWork.ProjectRepository.JoinProject(id));
            var user = await GetUser(id);
            if (projects is null) return user;
            user.Projects = projects;
            return user;
        }

        public async Task<UserDTO> LoginAsync(string username, string password)
        {
            return _mapper.Map<UserDTO>(await _unitOfWork.UserRepository.LoginAsync(username, password));
        }

        public async Task UpdateAsync(UserDTO userDTO)
        {
            _unitOfWork.UserRepository.Update(_mapper.Map<User>(userDTO));
            await _unitOfWork.SaveAsync();
        }

        public async Task<UserDTO> JoinTaskItemAsync(int id)
        {
            var tasks = _mapper.Map<IReadOnlyList<TaskItemDTO>>(await _unitOfWork.TaskItemRepository.JoinTaskAsyncToUser(id));
            var user = await GetUser(id);
            user.TaskItems = tasks;
            return user;
        }

    }
}
