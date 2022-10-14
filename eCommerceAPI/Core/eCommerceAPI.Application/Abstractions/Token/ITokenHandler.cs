using eCommerceAPI.Application.Dtos.TokenDtos;

namespace eCommerceAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(int expireMinute);
    }
}
