using AutoMapper;
using CSharpFunctionalExtensions;
using FluentValidation;
using System.Net.Mail;
using ValconLibrary.Data.Repository.BookRents;
using ValconLibrary.Data.Repository.Books;
using ValconLibrary.Data.Repository.Users;
using ValconLibrary.DTO.BookRents;
using ValconLibrary.EmailService;
using ValconLibrary.Entities;

namespace ValconLibrary.Service.BookRents
{
    public class BookRentService : IBookRentService
    {
        private readonly IBookRentRepository _bookRentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookRentService> _logger;
        private readonly IEmailService _emailService;
        private readonly string _imageFolder;
        private readonly IValidator<BookRentDTO> _bookRentValidator;

        public BookRentService(IBookRentRepository bookRentRepository,
            IUserRepository userRepository, IBookRepository bookRepository,
            IMapper mapper, ILogger<BookRentService> logger,
            IEmailService emailService, IConfiguration configuration,
            IValidator<BookRentDTO> bookRentValidator)
        {
            _bookRentRepository = bookRentRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
            _emailService = emailService;
            _imageFolder = configuration["BookCoverSettings:ImageFolder"];
            _bookRentValidator = bookRentValidator;
        }

        public async Task<Result<List<RentHistoryBookDTO>, IEnumerable<string>>> GetRentsByBookId(Guid bookId)
        {
            _logger.LogInformation("Getting rents for book (Id: {bookId})", bookId);
            var errMessages = new List<string>();
            var book = await _bookRepository.GetByIdAsync(bookId);
            var rents = _bookRentRepository.GetRentsByBookId(bookId);
            if (book == null)
            {
                var errorMessage = string.Format("Book (Id: {0}) does not exist", bookId);
                _logger.LogWarning(errorMessage);
                errMessages.Add(errorMessage);
                return Result.Failure<List<RentHistoryBookDTO>, IEnumerable<string>>(errMessages);
            }
            _logger.LogInformation("Retrieved {rents} rents for book (Id: {bookId})", rents.Count, bookId);
            var rentHistoryBook = _mapper.Map<List<RentHistoryBookDTO>>(rents);
            return Result.Success<List<RentHistoryBookDTO>, IEnumerable<string>>(rentHistoryBook);
        }

        public async Task<Result<List<RentHistoryUserDTO>, IEnumerable<string>>> GetRentsByUserId(Guid userId)
        {
            _logger.LogInformation("Getting rents for user (Id: {userId})", userId);
            var errMessages = new List<string>();
            var user = _userRepository.GetUserById(userId);
            var rents = _bookRentRepository.GetRentsByUserId(userId);
            if (user == null)
            {
                var errorMessage = string.Format("User (Id: {0}) does not exist", userId);
                _logger.LogWarning(errorMessage);
                errMessages.Add(errorMessage);
                return Result.Failure<List<RentHistoryUserDTO>, IEnumerable<string>>(errMessages);
            }
            _logger.LogInformation("Retrieved {rents} rents for user (Id: {userId})", rents.Count, userId);
            var rentHistoryUser = _mapper.Map<List<RentHistoryUserDTO>>(rents);
            return Result.Success<List<RentHistoryUserDTO>, IEnumerable<string>>(rentHistoryUser);
        }


        public async Task<Result<BookRentDTO, IEnumerable<string>>> RentBook(Guid userId, BookRentDTO bookRentDTO)
        {
            _logger.LogInformation("User (Id: {userId}) attempting to rent book (Id: {BookId})", userId, bookRentDTO.BookId);
            var errMessages = new List<string>();
            var user = _userRepository.GetUserById(userId);
            var book = await _bookRepository.GetByIdAsync(bookRentDTO.BookId);

            if (user == null || book == null)
            {
                var errorMessage = "Invalid user or book ID";
                _logger.LogWarning(errorMessage);
                errMessages.Add(errorMessage);
                return Result.Failure<BookRentDTO, IEnumerable<string>>(errMessages);
            }

            var activeRentsCount = _bookRentRepository.GetActiveRentsCount(bookRentDTO.BookId);
            if (activeRentsCount >= book.TotalCopies)
            {
                var errorMessage = "Book is not available";
                _logger.LogWarning(errorMessage);
                errMessages.Add(errorMessage);
                return Result.Failure<BookRentDTO, IEnumerable<string>>(errMessages);
            }

            var validationResult = _bookRentValidator.Validate(bookRentDTO);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                _logger.LogWarning("Validation failed for new rent: \n{Errors}", string.Join("\n", errors));
                return Result.Failure<BookRentDTO, IEnumerable<string>>(errors);
            }

            var rent = new BookRent
            {
                UserId = userId,
                BookId = bookRentDTO.BookId,
                RentDate = bookRentDTO.RentDate ?? DateTime.UtcNow,
                RentalPeriodInDays = bookRentDTO.RentalPeriodInDays
            };

            var emailSubject = "Book Rental Confirmation";
            string attachmentPath = _imageFolder + book.CoverImage;
            AlternateView emailBody = EmailTemplateGenerator.GenerateBookRentConfirmationEmail(user.FirstName, book, rent, attachmentPath);

            var email = new Email
            {
                ToEmail = user.Email,
                Subject = emailSubject,
                Body = emailBody,
                AttachmentPath = attachmentPath
            };

            _emailService.SendEmailWithAttachment(email);

            _bookRentRepository.AddRent(rent);
            _logger.LogInformation("User (Id: {userId}) rented book (Id: {BookId})", userId, bookRentDTO.BookId);
            var rentBook = _mapper.Map<BookRentDTO>(rent);
            return Result.Success<BookRentDTO, IEnumerable<string>>(rentBook);
        }

        public async Task<Result<BookReturnDTO, IEnumerable<string>>> ReturnBook(Guid userId, BookReturnDTO bookReturnDTO)
        {
            _logger.LogInformation("User (Id: {userId}) attempting to return book (Id: {BookId})", userId, bookReturnDTO.BookId);
            var errMessages = new List<string>();
            var user = _userRepository.GetUserById(userId);
            var book = await _bookRepository.GetByIdAsync(bookReturnDTO.BookId);
            if (user == null || book == null)
            {
                var errorMessage = "Invalid user or book ID";
                _logger.LogWarning(errorMessage);
                errMessages.Add(errorMessage);
                return Result.Failure<BookReturnDTO, IEnumerable<string>>(errMessages);
            }

            var rent = _bookRentRepository.GetActiveRent(userId, bookReturnDTO.BookId);
            if (rent == null)
            {
                var errorMessage = "No active rent found for this user and book";
                _logger.LogWarning(errorMessage);
                errMessages.Add(errorMessage);
                return Result.Failure<BookReturnDTO, IEnumerable<string>>(errMessages);
            }

            rent.ReturnDate = bookReturnDTO.ReturnDate ?? DateTime.UtcNow;

            _bookRentRepository.UpdateRent(rent);
            _logger.LogInformation("User (Id: {userId}) returned book (Id: {BookId})", userId, bookReturnDTO.BookId);
            var returnBook = _mapper.Map<BookReturnDTO>(rent);
            return Result.Success<BookReturnDTO, IEnumerable<string>>(returnBook);
        }
    }
}
