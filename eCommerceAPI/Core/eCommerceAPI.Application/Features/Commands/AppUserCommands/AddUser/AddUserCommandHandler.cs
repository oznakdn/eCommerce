using eCommerceAPI.Application.Exceptions;
using eCommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace eCommerceAPI.Application.Features.Commands.AppUserCommands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommandRequest, AddUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public AddUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = new()
            {
                Id = Guid.NewGuid().ToString(),
                NameSurname = request.NameSurname,
                UserName = request.UserName,
                Email = request.Email,
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
                return new AddUserCommandResponse(true,"Use is added successfully." );

            return new AddUserCommandResponse(false, "An unexpected error occurred while creating the user");

            //var errorMessages = result.Errors.Select(x => x.Description).ToList();
            //throw new UserCreateFailedException(errorMessages);

        }
    }
}
