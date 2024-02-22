using FluentValidation;

namespace Northwind.Application.Features.AuthFeature.Auth.Queries
{
    public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailQuery>
    {
        public ConfirmEmailValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Invalid user id")
                .NotNull().WithMessage("Invalid user id");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Invalid confirmation email code token")
                .NotNull().WithMessage("Invalid confiramtion email code token");
        }
    }
}
