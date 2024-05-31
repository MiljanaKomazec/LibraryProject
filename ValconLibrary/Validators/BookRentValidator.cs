using FluentValidation;
using ValconLibrary.DTO.BookRents;

namespace ValconLibrary.Validators
{
    public class BookRentValidator : AbstractValidator<BookRentDTO>
    {
        public BookRentValidator() 
        {
            RuleFor(r => r.RentalPeriodInDays)
            .InclusiveBetween(1, 365)
            .WithMessage("Rental period must be between 1 and 365 days.");
        }
    }
}
