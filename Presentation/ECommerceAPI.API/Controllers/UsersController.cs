using Azure.Core;
using ECommerceAPI.Application.Attributes;
using ECommerceAPI.Application.Enums;
using ECommerceAPI.Application.Features.Commands.UserCommands.AssignRoleToUser;
using ECommerceAPI.Application.Features.Commands.UserCommands.CreateUser;
using ECommerceAPI.Application.Features.Commands.UserCommands.LoginUser;
using ECommerceAPI.Application.Features.Commands.UserCommands.UpdatePassword;
using ECommerceAPI.Application.Features.Queries.CategoryQueries.GetAllCategories;
using ECommerceAPI.Application.Features.Queries.UserQueries.GetAllUsers;
using ECommerceAPI.Application.Features.Queries.UserQueries.GetRolesToUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            return Ok(await _mediator.Send(createUserCommandRequest));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordCommandRequest request)
            => Ok(await _mediator.Send(request));

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get All Users", Menu = "Users")]
        public async Task<IActionResult> GetAllUsers([FromQuery]GetAllUserQueryRequest request)
            => Ok(await _mediator.Send(request));

        [HttpGet("[action]/{UserId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles To Users", Menu = "Users")]
        public async Task<IActionResult> GetRolesToUser([FromRoute]GetRolesToUserQueryRequest request) 
            => Ok(await _mediator.Send(request));

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Assign Role To User", Menu = "Users")]
        public async Task<IActionResult> AssignRoleToUser([FromBody]AssignRoleToUserCommandRequest request)
             => Ok(await _mediator.Send(request));
    }
}
