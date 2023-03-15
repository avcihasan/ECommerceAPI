﻿using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Repositories.CategoryRepositories;
using ECommerceAPI.Application.Repositories.FileRepositories;
using ECommerceAPI.Application.Repositories.InvoiceFileRepositories;
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
        Task SaveAsync();
    }
}
