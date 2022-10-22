using eCommerceAPI.Application.Features.Commands.AppUserCommands.AddUser;
using eCommerceAPI.Application.Features.Commands.AppUserCommands.LoginRefreshUser;
using eCommerceAPI.Application.Features.Commands.AppUserCommands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [ActionName("Register")]
        public async Task<IActionResult> Register([FromBody] AddUserCommandRequest request)
        {
            AddUserCommandResponse response;
            if (ModelState.IsValid)
            {
                response = await mediator.Send(request);

                return Ok(response.ResponseMessage);
            }
            return BadRequest(new AddUserCommandResponse(false, "Inputs is invalid!"));
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("refreshToken")]
        [ActionName("LoginRefreshToken")]
        public async Task<IActionResult> RefreshLogin(string refreshToken)
        {
            var response = await mediator.Send(new LoginRefreshUserCommandRequest { RefreshToken=refreshToken});
            return Ok(response);
        }


    }
}
