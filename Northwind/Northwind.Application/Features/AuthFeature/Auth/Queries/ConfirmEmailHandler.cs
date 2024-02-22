using MediatR;
using Microsoft.AspNetCore.Identity;
using Northwind.Core.Entities.Identity;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.AuthFeature.Auth.Queries
{
    public class ConfirmEmailHandler : ResponseHandler, IRequestHandler<ConfirmEmailQuery, GenericResponse<object>>
    {
        private readonly UserManager<NorthwindUser> _userManager;

        public ConfirmEmailHandler(UserManager<NorthwindUser> userManager)
        {
            this._userManager = userManager;
        }
        public async Task<GenericResponse<object>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user == null) return NotFound<object>("Incorrect user id");

            var confirmEmail = await _userManager.ConfirmEmailAsync(user, request.Code!);

            if (!confirmEmail.Succeeded)
                return BadRequest<object>(string.Join(",", confirmEmail.Errors.Select(e => e.Description)));


            return Succeeded<object>(null!, message: "Email confirmed");
        }
    }
}
