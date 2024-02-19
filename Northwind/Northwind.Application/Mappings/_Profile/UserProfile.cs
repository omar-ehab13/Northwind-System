using AutoMapper;
using Northwind.Application.Features.AuthFeature.Users.Commands.AddUser;
using Northwind.Infrastructure.Data;

namespace Northwind.Application.Mappings._Profile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUserCommand, NorthwindContext>();
        }
    }
}
