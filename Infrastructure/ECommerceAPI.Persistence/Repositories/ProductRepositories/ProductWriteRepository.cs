using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace ECommerceAPI.Persistence.Repositories.ProductRepositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ECommerceAPIDbContext context) : base(context)
        {
            
        }

        public async Task AddCategoryByProductId(string productId,string categoryId)
        {

            Product product = await _dbSet.FindAsync(Guid.Parse(productId));
            Category category = await _context.Categories.FindAsync(Guid.Parse(categoryId));
            product.Categories.Add(new() { CategoryId = category.Id });
            
        }
    }
}
    