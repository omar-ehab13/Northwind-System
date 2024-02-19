using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.AuthFeature.Auth.Commands.Login
{
    public class LoginCommand : IRequest<GenericResponse<object>>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
