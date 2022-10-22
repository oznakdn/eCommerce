using MediatR;

namespace eCommerceAPI.Application.Features.Commands.AppUserCommands.LoginRefreshUser
{
    public class LoginRefreshUserCommandRequest:IRequest<LoginRefreshUserCommandResponse>
    {
        public string RefreshToken { get; set; }
    }

}
