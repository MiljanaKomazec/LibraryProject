using AutoMapper;
using CSharpFunctionalExtensions;
using FluentValidation;
using ValconLibrary.Constants;
using ValconLibrary.Data.Repository.Authors;
using ValconLibrary.Data.Repository.Books;
using ValconLibrary.DTO.Books;
using ValconLibrary.Entities;


namespace ValconLibrary.Service.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IValidator<BookCreateDTO> _bookValidator;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;
        private readonly string _imageFolder;

        public BookService(IBookRepository bookRepository, IValidator<BookCreateDTO> bookValidator,
            IAuthorRepository authorRepository, IMapper mapper, ILogger<BookService> logger,
            IConfiguration configuration)
        {
            _bookRepository = bookRepository;
            _bookValidator = bookValidator;
            _authorRepository = authorRepository;
            _mapper = mapper;
            _logger = logger;
            _imageFolder = configuration["BookCoverSettings:ImageFolder"];
        }

        public async Task<List<BookDTO>> GetAllAsync()
        {
            _logger.LogInformation("Getting all books");
            var books = await _bookRepository.GetAllAsync();
            _logger.LogInformation("Retrieved {Count} books", books.Count);
            return _mapper.Map<List<BookDTO>>(books);
        }

        public async Task<BookDTO> GetByIdAsync(Guid bookId)
        {
            _logger.LogInformation("Getting book (Id: {bookId})", bookId);
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book == null)
            {
                _logger.LogWarning("Book (Id: {bookId}) not found", bookId);
            }
            return _mapper.Map<BookDTO>(book);
        }
        public async Task<Result<BookDTO, IEnumerable<string>>> CreateAsync(BookCreateDTO bookDTO)
        {
            _logger.LogInformation("Creating book (Title: {Title})", bookDTO.Title);
            var errMessages = new List<string>();
            var validationResult = _bookValidator.Validate(bookDTO);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                _logger.LogWarning("Validation failed for new book: \n{Errors}", string.Join("\n", errors));
                return Result.Failure<BookDTO, IEnumerable<string>>(errors);
            }

            string uniqueFileName = string.Empty;
            if (bookDTO.CoverImage != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + bookDTO.CoverImage.FileName;
                string fullImagePath = Path.Combine(_imageFolder, uniqueFileName);

                using (FileStream fs = File.Create(fullImagePath))
                {
                    await bookDTO.CoverImage.CopyToAsync(fs);
                }
            }

            var newBook = new Book
            {
                BookId = Guid.NewGuid(),
                Title = bookDTO.Title,
                ISBN = bookDTO.ISBN,
                Genre = Enum.Parse<Genre>(bookDTO.Genre),
                NumberOfPages = bookDTO.NumberOfPages,
                PublishingYear = bookDTO.PublishingYear,
                TotalCopies = bookDTO.TotalCopies,
                CoverImage = uniqueFileName
            };

            var authors = await _authorRepository.GetAuthors(bookDTO.AuthorIds);

            if (authors.Count != bookDTO.AuthorIds.Count)
            {
                var errorMessage = "You have not entered a good author/s.";
                _logger.LogWarning(errorMessage);
                errMessages.Add(errorMessage);
                return Result.Failure<BookDTO, IEnumerable<string>>(errMessages);
            }

            foreach (var author in authors)
            {
                newBook.Authors.Add(author);
            }

            await _bookRepository.CreateAsync(newBook);
            _logger.LogInformation("Book created (Id: {BookId})", newBook.BookId);
            var bks = _mapper.Map<BookDTO>(newBook);
            return Result.Success<BookDTO, IEnumerable<string>>(bks);
        }

        public async Task<Result<BookDTO, IEnumerable<string>>> UpdateAsync(BookUpdateDTO bookUpdateDTO)
        {
            _logger.LogInformation("Updating book (Id: {BookId})", bookUpdateDTO.BookId);
            var existingBook = await _bookRepository.GetByIdAsync(bookUpdateDTO.BookId);
            var errMessages = new List<string>();
            if (existingBook == null)
            {
                var errorMessage = string.Format("Book (Id: {0}) does not exist", bookUpdateDTO.BookId);
                _logger.LogWarning(errorMessage);
                errMessages.Add(errorMessage);
                return Result.Failure<BookDTO, IEnumerable<string>>(errMessages);
            }

            var existingAuthors = await _authorRepository.GetAuthors(bookUpdateDTO.AuthorIds);

            existingBook.Authors.Clear();

            foreach (var author in existingAuthors)
            {
                existingBook.Authors.Add(author);
            }

            existingBook.Title = bookUpdateDTO.Title;
            existingBook.Genre = bookUpdateDTO.Genre;
            existingBook.PublishingYear = bookUpdateDTO.PublishingYear;
            existingBook.TotalCopies = bookUpdateDTO.TotalCopies;

            await _bookRepository.UpdateAsync(existingBook);
            _logger.LogInformation("Book updated (Id: {BookId})", existingBook.BookId);
            var bks = _mapper.Map<BookDTO>(existingBook);
            return Result.Success<BookDTO, IEnumerable<string>>(bks);
        }

        public async Task<bool> DeleteAsync(Guid bookId)
        {
            _logger.LogInformation("Deleting book (Id: {bookId})", bookId);
            var isDeleted = await _bookRepository.DeleteAsync(bookId);
            if (!isDeleted)
            {
                _logger.LogWarning("Book (Id: {bookId}) not found", bookId);
            }
            return isDeleted;
        }
    }
}