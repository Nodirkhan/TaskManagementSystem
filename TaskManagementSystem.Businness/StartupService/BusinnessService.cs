using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Businness.Interfaces;
using TaskManagementSystem.Businness.Profiles;
using TaskManagementSystem.Businness.Services;

namespace TaskManagementSystem.Businness.StartupService
{
    public static class BusinnessService
    {
        public static void AddBusinnessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappinInitializer));

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ITaskItemService,TaskItemService>();
            services.AddTransient<ITaskStatusItemService, TaskStatusItemService>();
        }
    }
}
