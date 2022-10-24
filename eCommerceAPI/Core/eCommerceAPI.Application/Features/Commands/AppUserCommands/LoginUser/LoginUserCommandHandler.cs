using eCommerceAPI.Application.Abstractions.Token;
using eCommerceAPI.Application.Dtos.TokenDtos;
using eCommerceAPI.Application.Exceptions;
using eCommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace eCommerceAPI.Application.Features.Commands.AppUserCommands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
           
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UsernameOrEmailAddress);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmailAddress);

            if (user == null)
                throw new UserNotFoundException("User not found!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if(result.Succeeded)
            {
                
                // Login basarili ise access token ve refresh token'i uretmek
                var accessToken = _tokenHandler.CreateAccessToken(30,user);
                //var refreshToken = _tokenHandler.CreateRefreshToken();


                // Uretilen refresh token ve expire suresini veri  tabaninda ilgili kullaniciya ekmelek
                user.RefreshToken = accessToken.RefreshToken;
                user.RefreshTokenEndDate = DateTime.UtcNow.AddMinutes(45);
                await _userManager.UpdateAsync(user);


                return new LoginUserCommandSuccessResponse
                {
                    Token = new TokenDto
                    {
                        AccessToken = accessToken.AccessToken,
                        RefreshToken = accessToken.RefreshToken,
                        ExpirationDate = DateTime.UtcNow.AddMinutes(30) 
                    } 
                };
            }
            //return new LoginUserCommandErrorResponse { ResponseMessage = "Username or Password is wrong!"};
            throw new UserAuthenticationException();


        }
    }
}
