using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.AuthFeature.Auth.Queries
{
    public class ConfirmEmailQuery : IRequest<GenericResponse<object>>
    {
        public string UserId { get; set; } = null!;
        public string? Code { get; set; }
    }
}
