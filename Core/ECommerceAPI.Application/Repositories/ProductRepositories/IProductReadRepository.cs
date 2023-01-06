using ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Repositories.ProductRepositories
{
    public interface IProductReadRepository:IReadRepository<Product>
    {
        Task<List<Product>> GetAllProductsAllPropertiesAsync(bool tracking = true);
        Task<Product> GetByIdProductAllPropertiesAsync(string id ,bool tracking = true);
    }
}
