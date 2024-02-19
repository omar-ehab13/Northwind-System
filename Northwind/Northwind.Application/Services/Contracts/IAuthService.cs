using Northwind.Core.Entities.Identity;

namespace Northwind.Application.Services.Contracts
{
    public interface IAuthService
    {
        Task<string> GenerateJwtAccessToken(NorthwindUser user);
    }
}