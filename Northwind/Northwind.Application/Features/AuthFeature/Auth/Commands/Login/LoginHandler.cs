using MediatR;
using Microsoft.AspNetCore.Identity;
using Northwind.Application.Services.Contracts;
using Northwind.Core.Entities.Identity;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.AuthFeature.Auth.Commands.Login
{
    public class LoginHandler : ResponseHandler, IRequestHandler<LoginCommand, GenericResponse<object>>
    {
        private readonly UserManager<NorthwindUser> _userManager;
        private readonly IAuthService _authService;

        public LoginHandler(UserManager<NorthwindUser> userManager, IAuthService authService)
        {
            this._userManager = userManager;
            this._authService = authService;
        }

        public async Task<GenericResponse<object>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
                return BadRequest<object>("Incorrect username");

            var isCorrectPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isCorrectPassword)
                return BadRequest<object>("Incorrect password");

            // Get JWT Token
            var accessToken = await _authService.GenerateJwtAccessToken(user);
            var result = new { AccessToken = accessToken };

            return Succeeded<object>(result);
        }
    }
}
