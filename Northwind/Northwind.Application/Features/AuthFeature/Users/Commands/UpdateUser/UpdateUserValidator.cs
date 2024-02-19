using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Northwind.Core.Entities.Identity;

namespace Northwind.Application.Features.AuthFeature.Users.Commands.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator(UserManager<NorthwindUser> userManager)
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Email Is Empty")
                 .NotNull().WithMessage("Email Is Required");

            RuleFor(x => new { x.Id, x.Email })
                .MustAsync(async (key, CancellationToken) =>
                        await userManager.Users
                        .FirstOrDefaultAsync(u => u.Email == key.Email && u.Id != key.Id) == null)
                .WithMessage("The email is already exists!");
        }
    }
}
