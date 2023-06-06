using ECommerceAPI.Application.DTOs.TokenDTOs;
using ECommerceAPI.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Services
{
    public interface IAuthService
    {
        Task<TokenDto> LoginAsync(LoginUserDto loginUser, int tokenLife);
        Task<TokenDto> RefreshTokenLoginAsync(string refreshToken);
        Task PasswordResetAsync(string email);
        Task<bool> CheckPasswordResetTokenAsync(string resetToken, string userId);
    }
}
