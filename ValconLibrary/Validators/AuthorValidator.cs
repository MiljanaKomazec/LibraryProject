using FluentValidation;
using ValconLibrary.Entities;
using ValconLibrary.Migrations;

namespace ValconLibrary.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(author => author.YearOfBirth)
                .InclusiveBetween(0, DateTime.UtcNow.Year)
                .WithMessage($"Year of birth must be between 0 and {DateTime.UtcNow.Year}.");
            RuleFor(author => author.FirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(author => author.LastName).NotEmpty().WithMessage("Last Name is required.");
        }
    }
}
