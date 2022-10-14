using MediatR;

namespace eCommerceAPI.Application.Features.Commands.AppUserCommands.LoginUser
{
    public class LoginUserCommandRequest:IRequest<LoginUserCommandResponse>
    {

        public string UsernameOrEmailAddress { get; set; }
        public string Password { get; set; }

    }
}
