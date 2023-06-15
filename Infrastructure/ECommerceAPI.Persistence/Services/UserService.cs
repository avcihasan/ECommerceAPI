using AutoMapper;
using Azure.Core;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.UserDTOs;
using ECommerceAPI.Application.Features.Commands.UserCommands.CreateUser;
using ECommerceAPI.Application.UnitOfWorks;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Identity;
using ECommerceAPI.Persistence.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        readonly IRepositoryManager _repositoryManager;

        public int TotalUserCount => _userManager.Users.Count();

        public UserService(IMapper mapper, UserManager<AppUser> userManager, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _repositoryManager = repositoryManager;
        }

        public async Task<CreateUserResponseDto> CreateUserAsync(CreateUserDto createUser)
        {
            AppUser addUser = _mapper.Map<AppUser>(createUser);

            addUser.Id = Guid.NewGuid().ToString();
            IdentityResult result = await _userManager.CreateAsync(addUser, createUser.Password);

            CreateUserResponseDto createUserResponseDto = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                createUserResponseDto.Message = ("Kayıt Başarılı");
            foreach (IdentityError error in result.Errors)
                createUserResponseDto.Message = (error.Description);
            return createUserResponseDto;
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new Exception("Kullanıcı bulunamadı");
        }

        public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword, string newPasswordConfirm)
        {
            if (!newPassword.Equals(newPasswordConfirm))
                throw new Exception("Şifre yenileme hatası .. ");

            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user is not null)
            {
                resetToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(resetToken));

                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
                if (result.Succeeded)
                    await _userManager.UpdateSecurityStampAsync(user);
                else
                    throw new Exception("Şifre yenileme hatası .. ");
            }
        }

        public async Task<List<UserDto>> GetAllUsersAsync(int page, int size)
            => _mapper.Map<List<UserDto>>(await _userManager.Users.Skip(page).Take(size).ToListAsync());

        public async Task<string[]> GetRolesToUserAsync(string userIdOrName)
        {
            AppUser user = await _userManager.FindByIdAsync(userIdOrName);
            if (user == null)
                user = await _userManager.FindByNameAsync(userIdOrName);
            if (user is null)
                throw new Exception("Kullanıcı bulunamadı");
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToArray();
        }

        public async Task AssignRoleToUserAsync(string userId, string[] roles)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user is null)
                throw new Exception("Kullanıcı bulunamadı");
            IList<string> _roles = await _userManager.GetRolesAsync(user);
            IdentityResult removeResult = await _userManager.RemoveFromRolesAsync(user, _roles);
            if (!removeResult.Succeeded)
                throw new Exception("Rol silme hatası");
            IdentityResult addResult = await _userManager.AddToRolesAsync(user, roles);
            if (!addResult.Succeeded)
                throw new Exception("Rol ekleme hatası");
        }

        public async Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
        {
            var userRoles = await GetRolesToUserAsync(name);

            if (!userRoles.Any())
                return false;

            Endpoint endpoint = await _repositoryManager.EndpointReadRepository.Table
                     .Include(e => e.Roles)
                     .FirstOrDefaultAsync(e => e.Code == code);

            if (endpoint == null)
                return false;

            var endpointRoles = endpoint.Roles.Select(r => r.Name);

            foreach (var userRole in userRoles)
            {
                foreach (var endpointRole in endpointRoles)
                    if (userRole == endpointRole)
                        return true;
            }

            return false;
        }
    }
}