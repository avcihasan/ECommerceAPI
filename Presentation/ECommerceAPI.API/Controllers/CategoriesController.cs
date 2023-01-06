using ECommerceAPI.Application.Features.Commands.CategoryCommands.CreateCategory;
using ECommerceAPI.Application.Features.Commands.CategoryCommands.RemoveByIdCategory;
using ECommerceAPI.Application.Features.Commands.CategoryCommands.UpdateCategory;
using ECommerceAPI.Application.Features.Queries.CategoryQueries.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            await _mediator.Send(createCategoryCommandRequest);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            GetAllCategoriesQueryRequest getAllCategoriesQueryRequest = new();
            return Ok(await _mediator.Send(getAllCategoriesQueryRequest));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            await _mediator.Send(updateCategoryCommandRequest);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveByIdCategory([FromRoute]RemoveByIdCategoryCommandRequest removeByIdCategoryCommandRequest)
        {
            await _mediator.Send(removeByIdCategoryCommandRequest);
            return Ok();
        }
    }
}
