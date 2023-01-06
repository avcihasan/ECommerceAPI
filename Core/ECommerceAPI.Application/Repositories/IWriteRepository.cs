using ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Repositories
{
    public interface IWriteRepository<T>:IGenericRepository<T> where T: BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Update(T entity);
        bool Remove(T entity);
        Task<bool> RemoveByIdAsync(string id);
        
    }
}
