using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.ModelDTOs;
using TaskManagementSystem.Entities;
using TaskManagementSystem.Infrastructure.Interfaces;

namespace TaskManagementSystem.Businness.Services
{
    public class TaskItemService : ITaskItemService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TaskItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<TaskItemDTO> CreateAsync(TaskItemModel taskItemModel)
        {
            var task = _mapper.Map<TaskItem>(taskItemModel);
            await _unitOfWork.TaskItemRepository.CreateAsync(task);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<TaskItemDTO>(task);
        }

        public async Task DeleteAsync(int Id)
        {
            _unitOfWork.TaskItemRepository.Delete(Id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IReadOnlyList<TaskItemDTO>> GetAllAsync()
        {
            return _mapper.Map<IReadOnlyList<TaskItemDTO>>(await _unitOfWork.TaskItemRepository.GetAllAsync());
        }

        public async Task<IReadOnlyList<TaskItemDTO>> GetPageListAsync(int page, int pageSize)
        {
            return _mapper.Map<IReadOnlyList<TaskItemDTO>>(
                   await _unitOfWork.TaskItemRepository.GetPageListAsync(page, pageSize));

        }

        public async Task<TaskItemDTO> GetTaskitem(int id)
        {
            return _mapper.Map<TaskItemDTO>(await _unitOfWork.TaskItemRepository
                .GetByIdAsync(user => user.Id == id, new List<string> { "Status", "User", "Project" }));
        }

        public async Task UpdateAsync(TaskItemDTO taskItemDTO)
        {
            _unitOfWork.TaskItemRepository.Update(_mapper.Map<TaskItem>(taskItemDTO));
            await _unitOfWork.SaveAsync();
        }
    }
}
