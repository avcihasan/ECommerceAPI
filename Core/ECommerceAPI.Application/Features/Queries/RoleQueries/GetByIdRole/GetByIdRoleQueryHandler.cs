using AutoMapper;
using ECommerceAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.RoleQueries.GetByIdRole
{
    public class GetByIdRoleQueryHandler : IRequestHandler<GetByIdRoleQueryRequest, GetByIdRoleQueryResponse>
    {
        readonly IRoleService _roleService;
        readonly IMapper _mapper;
        public GetByIdRoleQueryHandler(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public async Task<GetByIdRoleQueryResponse> Handle(GetByIdRoleQueryRequest request, CancellationToken cancellationToken)
            => _mapper.Map<GetByIdRoleQueryResponse>(await _roleService.GetRoleByIdAsync(request.Id));
    }
}
