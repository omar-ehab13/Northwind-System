using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Northwind.Application.Services.Contracts;
using Northwind.Core.Entities.Identity;
using Northwind.Core.Helpers.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Northwind.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly UserManager<NorthwindUser> _userManager;

        public AuthService(UserManager<NorthwindUser> userManager, JwtOptions jwtOptions)
        {
            this._jwtOptions = jwtOptions;
            this._userManager = userManager;
        }

        public async Task<string> GenerateJwtAccessToken(NorthwindUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim("uid", user.Id),
                //new Claim("roles", roles.FirstOrDefault()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            }
            .Union(await _userManager.GetClaimsAsync(user));

            var secret = Encoding.UTF8.GetBytes(_jwtOptions.Secret);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwtOptions.AccessTokenExpireDate),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
