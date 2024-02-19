using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.AuthFeature.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<GenericResponse<object>>
    {
        public string? Id { get; set; }
        public string Email { get; set; } = null!;
    }
}
