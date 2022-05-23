using AutoMapper;
using TaskManagementSystem.Businness.ModelDTOs;
using TaskManagementSystem.Entities;

namespace TaskManagementSystem.Businness.Profiles
{
    public class MappinInitializer : Profile
    {
        public MappinInitializer()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();

            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<Project, ProjectModel>().ReverseMap();

            CreateMap<TaskItem, TaskItemDTO>().ReverseMap();
            CreateMap<TaskItem, TaskItemModel>().ReverseMap();

            CreateMap<TaskStatusItem, TaskStatusItemDTO>().ReverseMap();
            CreateMap<TaskStatusItem, TaskStatusItemModel>().ReverseMap();
        }
    }
}
