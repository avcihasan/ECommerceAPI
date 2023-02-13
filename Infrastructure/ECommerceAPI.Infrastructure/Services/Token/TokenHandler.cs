using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Application.DTOs.TokenDTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto CreateAccessToken(int minute)
        {
            TokenDto token = new();
            //securitykey in simetriğini alıyoruz 
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SigninKey"]));
            //şifrelenmiş kimliği oluşturuyoruz 
            SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);

            //oluşturulacak  token ayarlarını  veriyoruz
            token.Expiration = DateTime.Now.AddMinutes(minute);

            JwtSecurityToken jwtSecurityToken = new(
                audience:_configuration["Token:SigninKey"],
                issuer: _configuration["Token:Issuer"],
                expires:token.Expiration,
                notBefore:DateTime.Now,
                signingCredentials:signingCredentials
                );

            //token oluşturucu sınıfından örnek alalım
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
