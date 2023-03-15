using AutoMapper;
using Azure.Core;
using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.UserDTOs;
using ECommerceAPI.Application.Features.Commands.UserCommands.CreateUser;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
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

        public UserService(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
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
    }
}
