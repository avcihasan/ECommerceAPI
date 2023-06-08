using ECommerceAPI.Application.DTOs.UserDTOs;
using ECommerceAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Services
{
    public interface IUserService
    {
        public int TotalUserCount { get; }
        Task<CreateUserResponseDto> CreateUserAsync(CreateUserDto createUser);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
        Task UpdatePasswordAsync(string userId, string resetToken, string newPassword, string newPasswordConfirm);
        Task<List<UserDto>> GetAllUsersAsync(int page, int size);
        Task<string[]> GetRolesToUserAsync(string userIdorName);
        Task AssignRoleToUserAsync(string userId, string[] roles);
        Task<bool> HasRolePermissionToEndpointAsync(string name, string code);
    }
}
