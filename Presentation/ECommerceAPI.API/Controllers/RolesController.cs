using Azure.Core;
using ECommerceAPI.Application.Attributes;
using ECommerceAPI.Application.Enums;
using ECommerceAPI.Application.Features.Commands.RoleCommands.CreateRole;
using ECommerceAPI.Application.Features.Commands.RoleCommands.DeleteRole;
using ECommerceAPI.Application.Features.Commands.RoleCommands.UpdateRole;
using ECommerceAPI.Application.Features.Queries.RoleQueries.GetAllRoles;
using ECommerceAPI.Application.Features.Queries.RoleQueries.GetByIdRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class RolesController : ControllerBase
    {
        readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles", Menu = "Roles")]
        public async Task<IActionResult> GetRoles([FromQuery] GetAllRolesQueryRequest request)
            => Ok(await _mediator.Send(request));

        [HttpGet("{id}")]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Role By Id", Menu = "Roles")]
        public async Task<IActionResult> GetRole([FromRoute] GetByIdRoleQueryRequest request)
         => Ok(await _mediator.Send(request));

        [HttpPost]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Role", Menu = "Roles")]
        public async Task<IActionResult> CreateRole([FromBody]CreateRoleCommandRequest request)
         => Ok(await _mediator.Send(request));

        [HttpPut("{id}")]
        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Role", Menu = "Roles")]
        public async Task<IActionResult> UpdateRole([FromBody, FromRoute] UpdateRoleCommandRequest request)
         => Ok(await _mediator.Send(request));

        [HttpDelete("{id}")]
        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Delete Role", Menu = "Roles")]
        public async Task<IActionResult> DeleteRole([FromRoute]DeleteRoleCommandRequest request)
         => Ok(await _mediator.Send(request));

    }
}
