using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskManagementSystem.Infrastructure.Data;
using TaskManagementSystem.Infrastructure.Interfaces;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public DbSet<T> dbset;

        public BaseRepositoryAsync(ApplicationDbContext context)
        {
            _context = context;
            dbset = context.Set<T>();
        }
        public virtual async Task<T> CreateAsync(T entity)
        {
            await dbset.AddAsync(entity);
            return entity;   
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            IReadOnlyList<T> entities = await dbset.AsNoTracking().ToListAsync();
            return entities;
        }

        public virtual async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression, IList<string> tables)
        {
            IQueryable<T> entities = dbset.AsNoTracking();
            foreach(var table in tables)
            {
                entities = entities.Include(table);
            }
            return await entities.FirstOrDefaultAsync(expression);
        }

        public virtual void Delete(int Id)
        {
            var entity = dbset.Find(Id);
            dbset.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<IReadOnlyList<T>> GetPageListAsync(int page, int pageSize)
        { 
            return await dbset.AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
