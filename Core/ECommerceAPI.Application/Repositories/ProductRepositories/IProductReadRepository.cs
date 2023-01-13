using ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Repositories.ProductRepositories
{
    public interface IProductReadRepository:IReadRepository<Product>
    {
        IQueryable<Product> GetAllProductsAllProperties(bool tracking = true);
        Task<Product> GetByIdProductAllPropertiesAsync(string id ,bool tracking = true);
    }
}
