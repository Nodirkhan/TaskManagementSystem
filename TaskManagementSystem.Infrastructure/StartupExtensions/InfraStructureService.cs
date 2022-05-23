using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagementSystem.Infrastructure.Data;
using TaskManagementSystem.Infrastructure.Interfaces;
using TaskManagementSystem.Infrastructure.Repositories;

namespace TaskManagementSystem.Infrastructure.StartupExtensions
{
    public static class InfraStructureService
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>      options.UseNpgsql(
                config.GetConnectionString("DefaultConnect"),
                m => m.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                ));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
            services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<ITaskItemRepository, TaskItemRepository>();
            services.AddTransient<ITaskStatusItemRepository, TaskStatusItemRepository>();
        }
    }
}
