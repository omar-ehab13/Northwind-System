using Northwind.Application.Features.AuthFeature.Users.Commands.AddUser;
using Northwind.Application.Features.AuthFeature.Users.Commands.UpdateUser;
using Northwind.Core.Entities.Identity;

namespace Northwind.Application.Mappings.UsersMapping
{
    public static class UserMappingProfile
    {
        public static NorthwindUser MapAddUserCommand(this AddUserCommand command)
        {
            return new()
            {
                UserName = command.UserName,
                Email = command.Email,
            };
        }

        public static NorthwindUser MapUpdateUserCommand(this UpdateUserCommand command, NorthwindUser user)
        {
            user.Email = command.Email;

            return user;
        }
    }
}
