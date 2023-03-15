using Azure.Core;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Application.DTOs.TokenDTOs;
using ECommerceAPI.Application.DTOs.UserDTOs;
using ECommerceAPI.Application.Features.Commands.UserCommands.LoginUser;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager; 
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<TokenDto> LoginAsync(LoginUserDto loginUser, int tokenLifeMinute)
        {
            AppUser user = await _userManager.FindByEmailAsync(loginUser.UserNameOrEmail);
            if (user == null)
                user = await _userManager.FindByNameAsync(loginUser.UserNameOrEmail);
            if (user == null)
                throw new Exception("Girilen Bilgileri Kontrol Ediniz");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginUser.Password, false);

            if (result.Succeeded)
                return _tokenHandler.CreateAccessToken(tokenLifeMinute);
            
            throw new Exception("Hatalı Giriş");
        }
    }
}
