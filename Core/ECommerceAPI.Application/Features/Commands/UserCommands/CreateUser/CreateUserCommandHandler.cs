using AutoMapper;
using ECommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            
            AppUser addUser = _mapper.Map<AppUser>(request);
           
            addUser.Id = Guid.NewGuid().ToString();
            IdentityResult result = await _userManager.CreateAsync(addUser, request.Password);

            CreateUserCommandResponse createUserCommandResponse = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                createUserCommandResponse.Message = ("Kayıt Başarılı");
            foreach (IdentityError error in result.Errors)
                createUserCommandResponse.Message = (error.Description);
            return createUserCommandResponse;
        }
    }
}
