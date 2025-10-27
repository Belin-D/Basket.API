using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basket.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Basket.DAL.Repositories
{
    public abstract class BaseRepositoryAsync<Key, T> : IRepository<Key, T>
        where T : class
    {
        protected readonly Context _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepositoryAsync(Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Key key)
        {
            return await _dbSet.FindAsync(key);
        }

        public virtual async Task<IEnumerable<T>> GetByIdsAsync(List<Key> keys)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(e => keys.Contains(EF.Property<Key>(e, "Id")))
                .ToListAsync();
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
