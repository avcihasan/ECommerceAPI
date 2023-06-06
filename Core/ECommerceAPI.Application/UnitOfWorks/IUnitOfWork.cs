using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Repositories.BasketItemRepositories;
using ECommerceAPI.Application.Repositories.BasketRepositories;
using ECommerceAPI.Application.Repositories.CategoryRepositories;
using ECommerceAPI.Application.Repositories.CompletedOrderRepositories;
using ECommerceAPI.Application.Repositories.FileRepositories;
using ECommerceAPI.Application.Repositories.InvoiceFileRepositories;
using ECommerceAPI.Application.Repositories.OrderRepositories;
using ECommerceAPI.Application.Repositories.ProductImageFileRepositories;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.UnitOfWorks
{
    public interface IUnitOfWork
    {
        ICategoryReadRepository CategoryReadRepository { get; }
        ICategoryWriteRepository CategoryWriteRepository { get; }

        IFileReadRepository FileReadRepository { get; }
        IFileWriteRepository FileWriteRepository { get; }

        IInvoiceFileReadRepository InvoiceFileReadRepository { get; }
        IInvoiceFileWriteRepository InvoiceFileWriteRepository { get; }

        IProductImageFileReadRepository ProductImageFileReadRepository { get; }
        IProductImageFileWriteRepository ProductImageFileWriteRepository { get; }

        IProductReadRepository ProductReadRepository { get; }
        IProductWriteRepository ProductWriteRepository { get; }

        IBasketReadRepository BasketReadRepository { get; }
        IBasketWriteRepository BasketWriteRepository { get; }

        IBasketItemReadRepository BasketItemReadRepository { get; }
        IBasketItemWriteRepository BasketItemWriteRepository { get; }

        IOrderWriteRepository OrderWriteRepository { get; }
        IOrderReadRepository OrderReadRepository { get; }
        ICompletedOrderReadRepository CompletedOrderReadRepository { get; }
        ICompletedOrderWriteRepository CompletedOrderWriteRepository { get; }

        Task SaveAsync();
    }
}
