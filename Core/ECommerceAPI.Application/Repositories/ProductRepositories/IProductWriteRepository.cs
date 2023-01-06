using ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Repositories.ProductRepositories
{
    public interface IProductWriteRepository:IWriteRepository<Product>
    {
        Task AddCategoryByProductId(string productId, string categoryId);
    }
}
