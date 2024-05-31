using FluentValidation;
using ValconLibrary.Constants;
using ValconLibrary.DTO.Books;
using ValconLibrary.Entities;

namespace ValconLibrary.Validators
{
    public class BookCreateValidator : AbstractValidator<BookCreateDTO> 
    {
        public BookCreateValidator() 
        {
            RuleFor(book => book.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(book => book.Genre).IsEnumName(typeof(Genre), caseSensitive: false)
            .WithMessage("Invalid Genre value."); 
            RuleFor(book => book.Genre).NotEmpty().WithMessage("Genre is required.");
            RuleFor(book => book.TotalCopies).GreaterThan(0)
                .WithMessage("Total Copies must be greater than zero.");
            RuleFor(book => book.PublishingYear).GreaterThan(0)
                .WithMessage("Publishing Year must be greater than zero.");
            RuleFor(book => book.ISBN)
                .NotEmpty()
                .WithMessage("ISBN is required.")
                .Must(IsValidISBN)
                .WithMessage("Invalid ISBN format.");
        }

        private bool IsValidISBN(string isbn)
        {
            return IsIsbn10(isbn) || IsIsbn13(isbn);
        }

        private bool IsIsbn10(string isbn)
        {
            return isbn.Length == 10;
        }

        private bool IsIsbn13(string isbn)
        {
            return isbn.Length == 13;
        }
    }
}
