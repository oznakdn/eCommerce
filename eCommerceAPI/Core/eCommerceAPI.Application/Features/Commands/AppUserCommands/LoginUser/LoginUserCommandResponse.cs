using eCommerceAPI.Application.Dtos.TokenDtos;

namespace eCommerceAPI.Application.Features.Commands.AppUserCommands.LoginUser
{
    public class LoginUserCommandResponse
    {
    }

    public class LoginUserCommandSuccessResponse: LoginUserCommandResponse
    {
        public TokenDto Token { get; set; }

    }

    public class LoginUserCommandErrorResponse: LoginUserCommandResponse
    {
        public string ResponseMessage { get; set; }

    }

}
