using MediatR;
using Microsoft.AspNetCore.Identity;
using Northwind.Application.Mappings.UsersMapping;
using Northwind.Core.Entities.Identity;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.AuthFeature.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : ResponseHandler, IRequestHandler<UpdateUserCommand, GenericResponse<object>>
    {
        private readonly UserManager<NorthwindUser> _userManager;

        public UpdateUserHandler(UserManager<NorthwindUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<GenericResponse<object>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null) return NotFound<object>("The user not found");

            var newUser = request.MapUpdateUserCommand(user);

            var result = await _userManager.UpdateAsync(newUser);

            if (!result.Succeeded)
                return BadRequest<object>(String.Join(",", result.Errors.Select(e => e.Description)));

            return Succeeded<object>(null!, message: "Updated");
        }
    }
}
