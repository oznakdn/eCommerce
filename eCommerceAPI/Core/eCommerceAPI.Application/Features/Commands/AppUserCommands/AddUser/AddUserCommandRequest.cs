using MediatR;
using System.ComponentModel.DataAnnotations;

namespace eCommerceAPI.Application.Features.Commands.AppUserCommands.AddUser
{
    public class AddUserCommandRequest:IRequest<AddUserCommandResponse>
    {
        [Required]
        public string NameSurname { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }


    }
}
