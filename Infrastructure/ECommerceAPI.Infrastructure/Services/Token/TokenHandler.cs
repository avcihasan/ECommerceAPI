using ECommerceAPI.Application.Abstractions.Token;
using ECommerceAPI.Application.DTOs.TokenDTOs;
using ECommerceAPI.Application.OptionsModels;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly TokenOptions _tokenOptions; 

        public TokenHandler(IOptions<TokenOptions> options)
        {
            _tokenOptions = options.Value;
        }

        public TokenDto CreateAccessToken(int minute, AppUser user)
        {
            TokenDto token = new();
            //securitykey in simetriğini alıyoruz 
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_tokenOptions.SigninKey));
            //şifrelenmiş kimliği oluşturuyoruz 
            SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);

            //oluşturulacak  token ayarlarını  veriyoruz
            token.Expiration = DateTime.Now.AddMinutes(minute);

            JwtSecurityToken jwtSecurityToken = new(
                audience: _tokenOptions.Audience,
                issuer: _tokenOptions.Issuer,
                expires:token.Expiration,
                notBefore:DateTime.Now,
                signingCredentials:signingCredentials,
                claims:new List<Claim> { new(ClaimTypes.Name,user.UserName)}
                );

            //token oluşturucu sınıfından örnek alalım
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
            token.RefreshToken = CreateRefreshToken();
            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
