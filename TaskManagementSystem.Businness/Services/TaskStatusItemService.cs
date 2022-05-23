using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;
using TaskManagementSystem.Entities;
using TaskManagementSystem.Infrastructure.Interfaces;

namespace TaskManagementSystem.Businness.Services
{
    public class TaskStatusItemService : ITaskStatusItemService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TaskStatusItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TaskStatusItemDTO> CreateAsync(TaskStatusItemModel taskStatusItemModel)
        {
            var status = _mapper.Map<TaskStatusItem>(taskStatusItemModel);
            await _unitOfWork.TaskStatusItemRepository.CreateAsync(status);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<TaskStatusItemDTO>(status);
        }

        public async Task DeleteAsync(int Id)
        {
            _unitOfWork.TaskStatusItemRepository.Delete(Id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IReadOnlyList<TaskStatusItemDTO>> GetAllAsync()
        {
            return _mapper.Map<IReadOnlyList<TaskStatusItemDTO>>(
                await _unitOfWork.TaskStatusItemRepository.GetAllAsync());
        }

        public async Task<IReadOnlyList<TaskStatusItemDTO>> GetPageListAsync(int page, int pageSize)
        {
            return _mapper.Map<IReadOnlyList<TaskStatusItemDTO>>(
                   await _unitOfWork.TaskStatusItemRepository.GetPageListAsync(page, pageSize));
        }

        public async Task<TaskStatusItemDTO> GetTaskStatus(int id)
        {
            return _mapper.Map<TaskStatusItemDTO>(await _unitOfWork.TaskStatusItemRepository
                .GetByIdAsync(user => user.Id == id, new List<string> ()));
        }

        public async Task<TaskStatusItemDTO> JoinAsyncTaskItem(int Id)
        {

            var tasks = _mapper.Map<IReadOnlyList<TaskItemDTO>>(await _unitOfWork.TaskItemRepository.JoinTaskAsyncToStatus(Id));
            var status = await GetTaskStatus(Id);
            status.Tasks = tasks;
            return status;
        }

        public async Task UpdateAsync(TaskStatusItemDTO taskStatusItemDTO)
        {
            _unitOfWork.TaskStatusItemRepository.Update(_mapper.Map<TaskStatusItem>(taskStatusItemDTO));
            await _unitOfWork.SaveAsync();
        }
        public async Task<IReadOnlyList<TaskStatusItemDTO>> JoinAsyncListTaskItem(int Id)
        {
            if(Id<=0) return null;
            var statuses = await GetAllAsync();
            var tasks = _mapper.Map<IReadOnlyList<TaskItemDTO>>(await _unitOfWork.TaskItemRepository.JoinTaskAsyncToProject(Id));
            foreach(var task in tasks)
            {
                task.UserDTO = _mapper.Map<UserDTO>(await _unitOfWork.UserRepository.GetByIdAsync(user=>user.Id == task.UserId, new List<string>()));
            }
            if(tasks.Count<=0) return statuses;
            foreach(var status in statuses)
            {
                status.Tasks = tasks.Where(task => task.TaskStatusId == status.Id).ToList();
            }
            return statuses;
        }
    }
}
