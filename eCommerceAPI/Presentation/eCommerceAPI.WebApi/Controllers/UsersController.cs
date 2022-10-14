using eCommerceAPI.Application.Features.Commands.AppUserCommands.AddUser;
using eCommerceAPI.Application.Features.Commands.AppUserCommands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create([FromBody] AddUserCommandRequest request)
        {
            AddUserCommandResponse response;
            if(ModelState.IsValid)
            {
                response = await mediator.Send(request);
           
                return Ok(response.ResponseMessage);
            }
            return BadRequest(new AddUserCommandResponse(false,"Inputs is invalid!"));
            
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
    }
}
