using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Persistence.Contexts;

namespace ECommerceAPI.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceAPIDbContext _context;

        public UnitOfWork(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
