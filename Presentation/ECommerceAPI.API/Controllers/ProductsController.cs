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
using ECommerceAPI.Application.Services;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IFileService _fileSerivce;


        private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        private readonly IFileWriteRepository _fileWriteRepository;
        private readonly IInvoiceFileWriteRepository _ınvoiceFileWriteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IMediator mediator, IFileService fileSerivce, IProductImageFileWriteRepository productImageFileWriteRepository, IUnitOfWork unitOfWork, IFileWriteRepository fileWriteRepository, IInvoiceFileWriteRepository ınvoiceFileWriteRepository)
        {
            _mediator = mediator;
            _fileSerivce = fileSerivce;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _unitOfWork = unitOfWork;
            _fileWriteRepository = fileWriteRepository;
            _ınvoiceFileWriteRepository = ınvoiceFileWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery]GetAllProductsQueryRequest getAllProductsQueryRequest)
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
        public async Task<IActionResult> Upload ()
        {
           var datas= await _fileSerivce.UploadAsync("resource/invoices",Request.Form.Files);

            await _ınvoiceFileWriteRepository.AddRangeAsync(datas.Select(d => new InvoiceFile()
            {
                FileName = d.fileName,
                Path = d.path,
                Price=new Random().Next()
               
            }).ToList()) ;
            await _unitOfWork.SaveAsync();
            

            return Ok();
        }
        

    }
}
