using FluentValidation;
using ValconLibrary.Entities;

namespace ValconLibrary.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Password).NotEmpty().WithMessage("Password is required.");
            RuleFor(user => user.Password).MinimumLength(8).WithMessage("Password must be at least 8 characters long.");
            RuleFor(user => user.Password).Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.");
            RuleFor(user => user.Password).Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.");
            RuleFor(user => user.Password).Matches("[0-9]").WithMessage("Password must contain at least one digit.");
            RuleFor(user => user.Password).Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

            RuleFor(user => user.Email).NotEmpty().WithMessage("Email address is required.");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Email address is not valid.");

            RuleFor(user => user.FirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(user => user.LastName).NotEmpty().WithMessage("Last Name is required.");
        }
    }
}
