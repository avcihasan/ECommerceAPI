using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Features.Commands.ProductCommands.CreateProduct;
using ECommerceAPI.Application.Features.Commands.ProductCommands.ProductAddToCategory;
using ECommerceAPI.Application.Features.Commands.ProductCommands.RemoveByIdProduct;
using ECommerceAPI.Application.Features.Commands.ProductCommands.UpdateProduct;
using ECommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts;
using ECommerceAPI.Application.Features.Queries.ProductQueries.GetByIdProduct;
using ECommerceAPI.Application.Repositories.FileRepositories;
using ECommerceAPI.Application.Repositories.InvoiceFileRepositories;
using ECommerceAPI.Application.Repositories.ProductImageFileRepositories;
using ECommerceAPI.Application.Repositories.ProductRepositories;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Persistence.Repositories.ProductRepositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;



        private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        private readonly IFileWriteRepository _fileWriteRepository;
        private readonly IInvoiceFileWriteRepository _ınvoiceFileWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IStorageService _storageService;

        private readonly IProductWriteRepository _repo;
        private readonly IProductReadRepository _repo1;
        private readonly IProductReadRepository _repo2;
        private readonly IConfiguration _configuration;

        public ProductsController(IMediator mediator, IProductImageFileWriteRepository productImageFileWriteRepository, IUnitOfWork unitOfWork, IFileWriteRepository fileWriteRepository, IInvoiceFileWriteRepository ınvoiceFileWriteRepository, IStorageService storageService, IProductWriteRepository repo, IProductReadRepository repo1, IProductReadRepository repo2, IConfiguration configuration)
        {
            _mediator = mediator;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _unitOfWork = unitOfWork;
            _fileWriteRepository = fileWriteRepository;
            _ınvoiceFileWriteRepository = ınvoiceFileWriteRepository;
            _storageService = storageService;
            _repo = repo;
            _repo1 = repo1;
            _repo2 = repo2;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQueryRequest getAllProductsQueryRequest)
        {
            return Ok(await _mediator.Send(getAllProductsQueryRequest));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdProduct([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            return Ok(await _mediator.Send(getByIdProductQueryRequest));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest createProductCommandRequest)
        {
            await _mediator.Send(createProductCommandRequest);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveByIdProduct([FromRoute] RemoveByIdProductCommandRequest removeByIdProductCommandRequest)
        {

            return Ok(await _mediator.Send(removeByIdProductCommandRequest));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest updateProductCommandRequest)
        {
            await _mediator.Send(updateProductCommandRequest);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddProductToCategory(ProductAddToCategoryRequest productAddToCategoryRequest)
        {
            await _mediator.Send(productAddToCategoryRequest);
            return Ok();
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(string id)
        {
            var datas = await _storageService.UploadAsync("resource/ProductImages", Request.Form.Files);

            Product p = await _repo1.GetByIdAsync(id);

            await _productImageFileWriteRepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
            {
                FileName = d.fileName,
                Path = d.pathOrContainerName,
                Storage = _storageService.StorageName,
                Products = new List<Product>() { p }

            }).ToList());
            await _unitOfWork.SaveAsync();


            return Ok();
        }


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductImages(string id)
        {
            Product? p = await _repo2.GetAll().Include(p => p.ProductImageFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));

            return Ok(p.ProductImageFiles.Select(x => new {
                Path = Path.Combine("../../../assets/", x.Path),
                x.FileName,
                x.Id
            }));
        }


        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteProductImage(string id, [FromQuery] string imageId)
        {
            Product? p = await _repo2.GetAll().Include(p => p.ProductImageFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));

            ProductImageFile file=p.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(imageId));
            p.ProductImageFiles.Remove(file);
            await _unitOfWork.SaveAsync();

            return Ok();

        }
    }
}
