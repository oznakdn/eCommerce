using eCommerceAPI.Application.Abstractions.Token;
using eCommerceAPI.Application.Dtos.TokenDtos;
using eCommerceAPI.Application.Exceptions;
using eCommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eCommerceAPI.Application.Features.Commands.AppUserCommands.LoginRefreshUser
{
    public class LoginRefreshUserCommandHandler : IRequestHandler<LoginRefreshUserCommandRequest, LoginRefreshUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;

        public LoginRefreshUserCommandHandler(UserManager<AppUser> userManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginRefreshUserCommandResponse> Handle(LoginRefreshUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken);

            /* Kullanici null degil ise ve kullanicinin refresh token bitis suresi, suan dan buyuk ise (yani bitis suresine henuz varsa)
               burada yeni bir access token olusturuyoruz ve access token ile birlikte yeni olusan refresh token'i user tablosunda yenisiyle
               guncelliyoruz.
             
             */
            if (user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                var accessToken = _tokenHandler.CreateAccessToken(30,user);
                user.RefreshToken = accessToken.RefreshToken;
                user.RefreshTokenEndDate = DateTime.UtcNow.AddMinutes(45);
                await _userManager.UpdateAsync(user);
                return new LoginRefreshUserCommandResponse
                {
                    Token = new TokenDto
                    {
                        AccessToken = accessToken.AccessToken,
                        RefreshToken = accessToken.RefreshToken,
                        ExpirationDate = accessToken.ExpirationDate
                    }
                };
            }

            throw new UserNotFoundException();
        }
    }
}
