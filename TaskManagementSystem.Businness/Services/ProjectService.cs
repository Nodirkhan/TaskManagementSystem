using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;
using TaskManagementSystem.Entities;
using TaskManagementSystem.Infrastructure.Interfaces;

namespace TaskManagementSystem.Businness.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProjectDTO> CreateAsync(ProjectModel projectModel)
        {

            var project = _mapper.Map<Project>(projectModel);
            await _unitOfWork.ProjectRepository.CreateAsync(project);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ProjectDTO>(project);
        }

        public async Task DeleteAsync(int Id)
        {
            _unitOfWork.ProjectRepository.Delete(Id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IReadOnlyList<ProjectDTO>> GetAllAsync()
        {
            return _mapper.Map<IReadOnlyList<ProjectDTO>>(await _unitOfWork.ProjectRepository.GetAllAsync());
        }

        public async Task<IReadOnlyList<ProjectDTO>> GetPageListAsync(int page, int pageSize)
        {
            return _mapper.Map<IReadOnlyList<ProjectDTO>>(
                await _unitOfWork.ProjectRepository.GetPageListAsync(page, pageSize));
        }

        public async Task<ProjectDTO> GetProject(int id)
        {
            return _mapper.Map<ProjectDTO>(await _unitOfWork.ProjectRepository
                .GetByIdAsync(user => user.Id == id, new List<string> {}));
        }

        public async Task<ProjectDTO> JoinTaskItemAsync(int Id)
        {

            var tasks = _mapper.Map<IReadOnlyList<TaskItemDTO>>(await _unitOfWork.TaskItemRepository.JoinTaskAsyncToProject(Id));
            var project = await GetProject(Id);
            if(tasks is not null && project is not null)
            {
             foreach(var task in tasks)
             {
                task.UserDTO = _mapper.Map<UserDTO>(await _unitOfWork.UserRepository
                    .GetByIdAsync(user => user.Id == task.UserId, new List<string>()));
                
                task.Status = _mapper.Map<TaskStatusItemDTO>(await _unitOfWork.TaskStatusItemRepository.
                     GetByIdAsync(status => status.Id == task.TaskStatusId, new List<string>()));
                }
            project.Tasks = tasks;
            }
            return project;
        }

        public async Task UpdateAsync(ProjectDTO project)
        {
            _unitOfWork.ProjectRepository.Update(_mapper.Map<Project>(project));
            await _unitOfWork.SaveAsync();
        }
    }
}


