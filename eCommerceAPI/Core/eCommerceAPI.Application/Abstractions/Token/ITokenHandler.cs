using eCommerceAPI.Application.Dtos.TokenDtos;
using eCommerceAPI.Domain.Entities.Identity;

namespace eCommerceAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(int expireMinute, AppUser user);
        string CreateRefreshToken();
    }
}
