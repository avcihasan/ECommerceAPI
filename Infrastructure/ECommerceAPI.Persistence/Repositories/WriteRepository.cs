using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ECommerceAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        protected readonly ECommerceAPIDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public WriteRepository(ECommerceAPIDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry entityEntry = await _dbSet.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }
        public async Task<bool> AddRangeAsync(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry entityEntry = _dbSet.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }
        public async Task<bool> RemoveByIdAsync(string id)
        {
            T entity = await _dbSet.FindAsync(Guid.Parse(id));
            return Remove(entity);
        }
        public bool Update(T entity)
        {
            EntityEntry entityEntry =_dbSet.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
