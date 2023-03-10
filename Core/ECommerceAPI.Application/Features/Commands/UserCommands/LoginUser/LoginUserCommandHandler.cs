using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Application.DTOs.TokenDTOs;
using ECommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.UserCommands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            if (user==null)
                user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if (user == null)
                throw new Exception("Girilen Bilgileri Kontrol Ediniz");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                TokenDto token = _tokenHandler.CreateAccessToken(5);
                return new LoginUserSuccessCommandResponse() { Token= token };
            }

            throw new Exception("Hatalı Giriş");
        }
    }
}
