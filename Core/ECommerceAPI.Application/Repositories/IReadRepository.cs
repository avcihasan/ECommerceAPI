using ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Repositories
{
    public interface IReadRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking=true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
    
}
