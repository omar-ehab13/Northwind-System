using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Northwind.Core.Entities.Identity;

namespace Northwind.Application.Features.AuthFeature.Users.Commands.AddUser
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserValidator(UserManager<NorthwindUser> userManager)
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("The UserName Is Empty")
                .NotNull().WithMessage("The UserName Is Required")
                .MaximumLength(100).WithMessage("Maximum length for username is 100 characters");

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Email Is Empty")
                 .NotNull().WithMessage("Email Is Required");

            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage("Password Is Empty!")
                 .NotNull().WithMessage("Password Is Required");

            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.Password).WithMessage("Not Matching with the password");

            RuleFor(x => x.Email)
                .MustAsync(async (key, CancellationToken) => await userManager.FindByEmailAsync(key) == null)
                .WithMessage("The email is already exists!");
        }
    }
}
