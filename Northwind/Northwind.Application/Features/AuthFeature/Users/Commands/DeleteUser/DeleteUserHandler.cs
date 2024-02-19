using MediatR;
using Microsoft.AspNetCore.Identity;
using Northwind.Core.Entities.Identity;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.AuthFeature.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : ResponseHandler, IRequestHandler<DeleteUserCommand, GenericResponse<object>>
    {
        private readonly UserManager<NorthwindUser> _userManager;

        public DeleteUserHandler(UserManager<NorthwindUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<GenericResponse<object>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user == null)
                return NotFound<object>("The user not found");

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                return BadRequest<object>(String.Join(",", result.Errors.Select(e => e.Description)));

            return Deleted<object>();
        }
    }
}
