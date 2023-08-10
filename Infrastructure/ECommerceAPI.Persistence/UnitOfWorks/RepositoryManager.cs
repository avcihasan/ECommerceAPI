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

namespace ECommerceAPI.Persistence.UnitOfWorks
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ECommerceAPIDbContext _context;

        public RepositoryManager(ECommerceAPIDbContext context, ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository, IFileReadRepository fileReadRepository, IFileWriteRepository fileWriteRepository, IInvoiceFileReadRepository ınvoiceFileReadRepository, IInvoiceFileWriteRepository ınvoiceFileWriteRepository, IProductImageFileReadRepository productImageFileReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IBasketReadRepository basketReadRepository, IBasketWriteRepository basketWriteRepository, IBasketItemReadRepository basketItemReadRepository, IBasketItemWriteRepository basketItemWriteRepository, IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository, ICompletedOrderReadRepository completedOrderReadRepository, ICompletedOrderWriteRepository completedOrderWriteRepository, IControllerReadRepository controllerReadRepository, IControllerWriteRepository controllerWriteRepository, IEndpointReadRepository endpointReadRepository, IEndpointWriteRepository endpointWriteRepository)
        {
            _context = context;
            CategoryReadRepository = categoryReadRepository;
            CategoryWriteRepository = categoryWriteRepository;
            FileReadRepository = fileReadRepository;
            FileWriteRepository = fileWriteRepository;
            InvoiceFileReadRepository = ınvoiceFileReadRepository;
            InvoiceFileWriteRepository = ınvoiceFileWriteRepository;
            ProductImageFileReadRepository = productImageFileReadRepository;
            ProductImageFileWriteRepository = productImageFileWriteRepository;
            ProductReadRepository = productReadRepository;
            ProductWriteRepository = productWriteRepository;
            BasketReadRepository = basketReadRepository;
            BasketWriteRepository = basketWriteRepository;
            BasketItemReadRepository = basketItemReadRepository;
            BasketItemWriteRepository = basketItemWriteRepository;
            OrderWriteRepository = orderWriteRepository;
            OrderReadRepository = orderReadRepository;
            CompletedOrderReadRepository = completedOrderReadRepository;
            CompletedOrderWriteRepository = completedOrderWriteRepository;
            ControllerReadRepository = controllerReadRepository;
            ControllerWriteRepository = controllerWriteRepository;
            EndpointReadRepository = endpointReadRepository;
            EndpointWriteRepository = endpointWriteRepository;
        }

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
      

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
