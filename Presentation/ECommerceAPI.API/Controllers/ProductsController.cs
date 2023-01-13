using ECommerceAPI.Application.Features.Commands.ProductCommands.CreateProduct;
using ECommerceAPI.Application.Features.Commands.ProductCommands.ProductAddToCategory;
using ECommerceAPI.Application.Features.Commands.ProductCommands.RemoveByIdProduct;
using ECommerceAPI.Application.Features.Commands.ProductCommands.UpdateProduct;
using ECommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts;
using ECommerceAPI.Application.Features.Queries.ProductQueries.GetByIdProduct;
using ECommerceAPI.Application.Repositories.ProductRepositories;
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
        private readonly IWebHostEnvironment _webHostEnviroment;

        public ProductsController(IMediator mediator, IWebHostEnvironment webHostEnviroment)
        {
            _mediator = mediator;
            _webHostEnviroment = webHostEnviroment;
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
            string uploadPath = Path.Combine(_webHostEnviroment.WebRootPath, "resource/product-images");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            Random r = new();
            foreach (IFormFile file in Request.Form.Files)
            {
                string fullPath = Path.Combine(uploadPath, $"{r.Next()}{Path.GetExtension(file.FileName)}");

                using FileStream fileStream=new(fullPath,FileMode.Create,FileAccess.Write,FileShare.None,1024 * 1024, useAsync:false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
            }

            return Ok();
        }


    }
}
