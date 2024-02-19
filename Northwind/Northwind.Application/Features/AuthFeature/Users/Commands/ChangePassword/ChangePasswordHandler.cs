using MediatR;
using Microsoft.AspNetCore.Identity;
using Northwind.Core.Entities.Identity;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.AuthFeature.Users.Commands.ChangePassword
{
    public class ChangePasswordHandler : ResponseHandler, IRequestHandler<ChangePasswordCommand, GenericResponse<object>>
    {
        private readonly UserManager<NorthwindUser> _userManager;

        public ChangePasswordHandler(UserManager<NorthwindUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<GenericResponse<object>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null) return NotFound<object>("user not found");

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

            if (!result.Succeeded)
                return BadRequest<object>(String.Join(",", result.Errors.Select(e => e.Description)));

            return Succeeded<object>(null!, message: "Password changed");
        }
    }
}
