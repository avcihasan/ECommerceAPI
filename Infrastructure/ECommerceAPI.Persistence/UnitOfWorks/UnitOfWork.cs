using ECommerceAPI.Application.Repositories.BasketItemRepositories;
using ECommerceAPI.Application.Repositories.BasketRepositories;
using ECommerceAPI.Application.Repositories.CategoryRepositories;
using ECommerceAPI.Application.Repositories.CompletedOrderRepositories;
using ECommerceAPI.Application.Repositories.ControllerRepositories;
using ECommerceAPI.Application.Repositories.EndpointRepositories;
using ECommerceAPI.Application.Repositories.FileRepositories;
using ECommerceAPI.Application.Repositories.InvoiceFileRepositories;
using ECommerceAPI.Application.Repositories.OrderRepositories;
using ECommerceAPI.Application.Repositories.ProductImageFileRepositories;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.BasketItemRepository;
using ECommerceAPI.Persistence.Repositories.BasketRepository;
using ECommerceAPI.Persistence.Repositories.CategoryRepositories;
using ECommerceAPI.Persistence.Repositories.CompletedOrderRepositories;
using ECommerceAPI.Persistence.Repositories.ControllerRepositories;
using ECommerceAPI.Persistence.Repositories.EndpointRepositories;
using ECommerceAPI.Persistence.Repositories.FileRepositories;
using ECommerceAPI.Persistence.Repositories.InvoiceFileRepositories;
using ECommerceAPI.Persistence.Repositories.OrderRepositories;
using ECommerceAPI.Persistence.Repositories.ProductImageFileRepositories;
using ECommerceAPI.Persistence.Repositories.ProductRepositories;

namespace ECommerceAPI.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceAPIDbContext _context;
        public ICategoryReadRepository CategoryReadRepository { get; private set; }
        public ICategoryWriteRepository CategoryWriteRepository { get; private set; }
        public IFileReadRepository FileReadRepository { get; private set; }
        public IFileWriteRepository FileWriteRepository { get; private set; }
        public IInvoiceFileReadRepository InvoiceFileReadRepository { get; private set; }
        public IInvoiceFileWriteRepository InvoiceFileWriteRepository { get; private set; }
        public IProductImageFileReadRepository ProductImageFileReadRepository { get; private set; }
        public IProductImageFileWriteRepository ProductImageFileWriteRepository { get; private set; }
        public IProductReadRepository ProductReadRepository { get; private set; }
        public IProductWriteRepository ProductWriteRepository { get; private set; }
        public IBasketReadRepository BasketReadRepository { get; private set; }
        public IBasketWriteRepository BasketWriteRepository { get; private set; }
        public IBasketItemReadRepository BasketItemReadRepository { get; private set; }
        public IBasketItemWriteRepository BasketItemWriteRepository { get; private set; }
        public IOrderWriteRepository OrderWriteRepository { get; private set; }
        public IOrderReadRepository OrderReadRepository { get; private set; }
        public ICompletedOrderReadRepository CompletedOrderReadRepository { get; private set; }
        public ICompletedOrderWriteRepository CompletedOrderWriteRepository { get; private set; }
        public IControllerReadRepository ControllerReadRepository { get; private set; }
        public IControllerWriteRepository ControllerWriteRepository { get; private set; }
        public IEndpointReadRepository EndpointReadRepository { get; private set; }
        public IEndpointWriteRepository EndpointWriteRepository { get; private set; }
        public UnitOfWork(ECommerceAPIDbContext context)
        {
            _context = context;
            CategoryReadRepository = new CategoryReadRepository(_context);
            CategoryWriteRepository = new CategoryWriteRepository(_context);
            FileReadRepository = new FileReadRepository(_context);
            FileWriteRepository = new FileWriteRepository(_context);
            InvoiceFileReadRepository = new InvoiceFileReadRepository(_context);
            InvoiceFileWriteRepository = new InvoiceFileWriteRepository(_context);
            ProductImageFileReadRepository = new ProductImageFileReadRepository(_context);
            ProductImageFileWriteRepository = new ProductImageFileWriteRepository(_context);
            ProductReadRepository = new ProductReadRepository(_context);
            ProductWriteRepository = new ProductWriteRepository(_context);
            BasketReadRepository = new BasketReadRepository(_context);
            BasketWriteRepository = new BasketWriteRepository(_context);
            BasketItemReadRepository = new BasketItemReadRepository(_context);
            BasketItemWriteRepository = new BasketItemWriteRepository(_context);
            OrderWriteRepository = new OrderWriteRepository(_context);
            OrderReadRepository = new OrderReadRepository(_context);
            CompletedOrderReadRepository = new CompletedOrderReadRepository(_context);
            CompletedOrderWriteRepository = new CompletedOrderWriteRepository(_context);
            ControllerReadRepository = new ControllerReadRepository(_context);
            ControllerWriteRepository = new ControllerWriteRepository(_context);
            EndpointWriteRepository = new EndpointWriteRepository(_context);
            EndpointReadRepository = new EndpointReadRepository(_context);
        }


        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
