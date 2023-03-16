using Azure.Core;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Application.DTOs.TokenDTOs;
using ECommerceAPI.Application.DTOs.UserDTOs;
using ECommerceAPI.Application.Features.Commands.UserCommands.LoginUser;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserService _userService;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
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
            {
                TokenDto token = _tokenHandler.CreateAccessToken(tokenLifeMinute,user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 15);
                return token;
            }
                
            
            throw new Exception("Hatalı Giriş");
        }


        public async Task<TokenDto> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                TokenDto token = _tokenHandler.CreateAccessToken(15,user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 15);
                return token;
            }
            else
                throw new Exception("Kullanıcı bulunamadı");
        }
    }
}
