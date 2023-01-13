using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Repositories.ProductRepositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {

        public ProductReadRepository(ECommerceAPIDbContext context) : base(context)
        {
  
        }

        public IQueryable<Product> GetAllProductsAllProperties(bool tracking = true)
        {
            IQueryable<Product> products = _dbSet
                .Include(p => p.Categories).ThenInclude(p=>p.Category)
                .Include(p=>p.ProductDetails); 
            if (tracking==false)
            {
                products.AsNoTracking();
            }

            return  products;
        }

        public async Task<Product> GetByIdProductAllPropertiesAsync(string id, bool tracking = true)
        {
            var products = _dbSet.Include(c => c.Categories);
            if (tracking == false)
            {
                products.AsNoTracking();
            }
            return await  products.FirstOrDefaultAsync(i => i.Id == Guid.Parse(id));

        }
    }
}
