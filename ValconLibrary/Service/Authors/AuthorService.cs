using AutoMapper;
using CSharpFunctionalExtensions;
using FluentValidation;
using ValconLibrary.Data.Repository.Authors;
using ValconLibrary.DTO.Authors;
using ValconLibrary.Entities;

namespace ValconLibrary.Service.Authors
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IValidator<Author> _authorValidator;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorService> _logger;

        public AuthorService(IAuthorRepository authorRepository, IValidator<Author> authorValidator,
            IMapper mapper, ILogger<AuthorService> logger)
        {
            _authorRepository = authorRepository;
            _authorValidator = authorValidator;
            _mapper = mapper;
            _logger = logger;
        }
        public List<AuthorDTO> GetAll()
        {
            _logger.LogInformation("Getting all authors");
            var authors = _authorRepository.GetAll();
            _logger.LogInformation("Retrieved {Count} authors", authors.Count);
            return _mapper.Map<List<AuthorDTO>>(authors);
        }

        public AuthorDTO GetById(Guid authorId)
        {
            _logger.LogInformation("Getting author (Id: {authorId}", authorId);
            var auth = _authorRepository.GetById(authorId);
            if (auth == null)
            {
                _logger.LogWarning("Author (Id: {authorId}) not found", authorId);
            }
            return _mapper.Map<AuthorDTO>(auth);
        }

        public async Task<Result<AuthorDTO, IEnumerable<string>>> Create(AuthorCreateDTO authorCreateDTO)
        {
            _logger.LogInformation("Creating author (First Name: {FirstName}, Last Name: {LastName})"
                , authorCreateDTO.FirstName, authorCreateDTO.LastName);
            Author author = _mapper.Map<Author>(authorCreateDTO);
            var errMessages = new List<string>();
            var validationResult = _authorValidator.Validate(author);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                _logger.LogWarning("Validation failed for new author: \n{Errors}", string.Join("\n", errors));
                return Result.Failure<AuthorDTO, IEnumerable<string>>(errors);
            }

            var newAuthor = new Author
            {
                AuthorId = Guid.NewGuid(),
                FirstName = author.FirstName,
                LastName = author.LastName,
                YearOfBirth = author.YearOfBirth
            };

            _authorRepository.Create(newAuthor);
            _logger.LogInformation("Author created (Id: {AuthorId})", newAuthor.AuthorId);
            var auth = _mapper.Map<AuthorDTO>(newAuthor);
            return Result.Success<AuthorDTO, IEnumerable<string>>(auth);
        }

        public async Task<Result<AuthorDTO, IEnumerable<string>>> Update(AuthorUpdateDTO authorUpdateDto)
        {
            _logger.LogInformation("Updating author (Id: {AuthorId})", authorUpdateDto.AuthorId);
            Author author = _mapper.Map<Author>(authorUpdateDto);
            var existingAuthor = _authorRepository.GetById(author.AuthorId);
            var errMessages = new List<string>();
            if (existingAuthor == null)
            {
                var errorMessage = string.Format("Author (Id: {0}) does not exist", authorUpdateDto.AuthorId);
                _logger.LogWarning(errorMessage);
                errMessages.Add(errorMessage);
                return Result.Failure<AuthorDTO, IEnumerable<string>>(errMessages);
            }

            var validationResult = _authorValidator.Validate(author);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                _logger.LogWarning("Validation failed for author update: \n{Errors}", string.Join("\n ", errors));
                return Result.Failure<AuthorDTO, IEnumerable<string>>(errors);
            }

            existingAuthor.FirstName = author.FirstName;
            existingAuthor.LastName = author.LastName;
            existingAuthor.YearOfBirth = author.YearOfBirth;

            _authorRepository.Update(existingAuthor);
            _logger.LogInformation("Author updated (Id: {AuthorId}", existingAuthor.AuthorId);
            var auth = _mapper.Map<AuthorDTO>(existingAuthor);
            return Result.Success<AuthorDTO, IEnumerable<string>>(auth);
        }

        public bool Delete(Guid authorId)
        {
            _logger.LogInformation("Deleting author (Id: {authorId})", authorId);
            var isDeleted = _authorRepository.Delete(authorId);
            if (!isDeleted)
            {
                _logger.LogWarning("Author (Id: {authorId}) not found", authorId);
            }
            return isDeleted;
        }
    }
}
