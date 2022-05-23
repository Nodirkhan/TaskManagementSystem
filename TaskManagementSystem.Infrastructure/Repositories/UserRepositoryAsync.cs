using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Entities;
using TaskManagementSystem.Infrastructure.Data;
using TaskManagementSystem.Infrastructure.Interfaces;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class UserRepositoryAsync : BaseRepositoryAsync<User>,IUserRepositoryAsync
    {
        private readonly DbSet<Project> _projects;
        private readonly DbSet<User> _users;

        public UserRepositoryAsync(ApplicationDbContext context ): base(context)
        {
            _users = context.Users;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await GetByIdAsync(user => user.UserName == username && user.Password == password,
                new List<string>());
            return user;
        }
            


    }
}
