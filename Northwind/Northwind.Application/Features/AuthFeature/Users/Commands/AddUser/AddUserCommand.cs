using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.AuthFeature.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<GenericResponse<object>>
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
