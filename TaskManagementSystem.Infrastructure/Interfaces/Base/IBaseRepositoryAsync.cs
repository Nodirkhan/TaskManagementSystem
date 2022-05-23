using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TaskManagementSystem.Infrastructure.Interfaces
{
    public interface IBaseRepositoryAsync<T> where T : class 
    {
        Task<T> CreateAsync(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetPageListAsync(int page, int pageSize);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, IList<string> tables);
        void Update(T entity);
        void Delete(int Id);

    }
}
