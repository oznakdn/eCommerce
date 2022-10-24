using eCommerceAPI.Application.Abstractions.Token;
using eCommerceAPI.Application.Dtos.TokenDtos;
using eCommerceAPI.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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

        public TokenDto CreateAccessToken(int expireMinute, AppUser user)
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
                signingCredentials: signingCredentials,
                claims:new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName)
                }

            );

            JwtSecurityTokenHandler tokenHandler = new();

            // Access Token olusturmak
            token.AccessToken = tokenHandler.WriteToken(jwtSecurity);

            // Refresh Token olusturmak
            token.RefreshToken = CreateRefreshToken();


            return token;

        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator randomNumber = RandomNumberGenerator.Create();
            randomNumber.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
