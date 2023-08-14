using AutoMapper;
using ECommerceAPI.Application.DTOs.MessageDTOs;
using ECommerceAPI.Application.UnitOfWorks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.MessageCommands
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommandRequest, CreateMessageCommandResponse>
    {
        readonly IServiceManager _serviceManager;
        readonly IMapper _mapper;

        public CreateMessageCommandHandler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<CreateMessageCommandResponse> Handle(CreateMessageCommandRequest request, CancellationToken cancellationToken)
        {
            await _serviceManager.MessageService.SendMessageAsync(_mapper.Map<SendMessageDto>(request));
            return new();
        }

    }
}
