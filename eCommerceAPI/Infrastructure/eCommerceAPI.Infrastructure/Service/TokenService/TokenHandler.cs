using eCommerceAPI.Application.Abstractions.Token;
using eCommerceAPI.Application.Dtos.TokenDtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace eCommerceAPI.Infrastructure.Service.TokenService
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto CreateAccessToken(int expireMinute)
        {
            // Geri dondurulecek nesne ornegi olusturmak
            TokenDto token = new();
            
            // Security Key'in simetrigini olusturmak
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["JwtToken:SecurityKey"]));

            // Sifrelenmis kimligi olusturmak
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            // Token'in sona erme zamanini olusturmak
            token.ExpirationDate = DateTime.UtcNow.AddMinutes(expireMinute);

            // Token ayarlarini olusturmak
            JwtSecurityToken jwtSecurity = new
            (
                audience: _configuration["JwtToken:Audience"],
                issuer: _configuration["JwtToken:Issuer"],
                expires: token.ExpirationDate,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
            );

            // Token'i olusturmak
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(jwtSecurity);

            return token;

        }
    }
}
