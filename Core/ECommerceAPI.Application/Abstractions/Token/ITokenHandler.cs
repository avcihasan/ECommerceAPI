using ECommerceAPI.Application.DTOs.TokenDTOs;
using ECommerceAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(int minute, AppUser user);
        string CreateRefreshToken();
    }
}
