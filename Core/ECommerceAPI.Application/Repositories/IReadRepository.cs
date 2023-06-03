using ECommerceAPI.Domain.Entities;
using System.Linq.Expressions;

namespace ECommerceAPI.Application.Repositories
{
    public interface IReadRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> method, bool tracking = true);
        IQueryable<T> GetAll(bool tracking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
    }

}
