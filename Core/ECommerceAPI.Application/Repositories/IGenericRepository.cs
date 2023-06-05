using ECommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Application.Repositories
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        public DbSet<T> Table { get;  }
    }
}
