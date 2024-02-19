using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.AuthFeature.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<GenericResponse<object>>
    {
        public DeleteUserCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
