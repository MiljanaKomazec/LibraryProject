using AutoMapper;
using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
using FluentValidation;
using ValconLibrary.Data.Repository.Users;
using ValconLibrary.DTO.Users;
using ValconLibrary.Entities;
using ValconLibrary.Helpers;

namespace ValconLibrary.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<User> _userValidator;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IValidator<User> userValidator,
            ILogger<UserService> logger,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Result<UserDTO, IEnumerable<string>>> Create(User user)
        {
            _logger.LogInformation("Creating user (Email: {Email})", user.Email);
            var validationResult = _userValidator.Validate(user);
            var errMessages = new List<string>();

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                _logger.LogWarning("Validation failed for new user: \n{Errors}", string.Join("\n", errors));
                return Result.Failure<UserDTO, IEnumerable<string>>(errors);
            }

            var emailExist = _userRepository.EmailExists(user.Email);
            if (emailExist)
            {
                var errorMessage = string.Format("User (Email: {0}) already exists", user.Email);
                _logger.LogWarning(errorMessage);
                errMessages.Add(errorMessage);
                return Result.Failure<UserDTO, IEnumerable<string>>(errMessages);
            }

            var password = PasswordHelper.HashPassword(user.Password);
            var newUser = new User
            {
                UserId = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role,
                Email = user.Email,
                Password = password.Item1,
                Salt = password.Item2
            };

            _userRepository.Create(newUser);
            _logger.LogInformation("User created (Email: {Email})", user.Email);
            var usr = _mapper.Map<UserDTO>(newUser);
            return Result.Success<UserDTO, IEnumerable<string>>(usr);
        }

        public List<UserDTO> GetAll(string role)
        {
            var users = _userRepository.GetAll(role);
            _logger.LogInformation("Retrieved {Count} users from the database", users.Count);
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<Result<UserDTO, IEnumerable<string>>> UpdateUserProfileAsync(Guid userId, User user)
        {
            _logger.LogInformation("Updating user profile (Id: {UserId})", userId);
            var existingUser = _userRepository.GetUserById(userId);
            var validationResult = _userValidator.Validate(user);
            var errMessages = new List<string>();
            if (existingUser == null)
            {
                var errorMessage = string.Format("User (Id: {0}) does not exist", user.UserId);
                _logger.LogWarning(errorMessage);
                errMessages.Add(errorMessage);
                return Result.Failure<UserDTO, IEnumerable<string>>(errMessages);
            }
            var relevantErrors = validationResult.Errors.Where(e =>
                e.PropertyName == nameof(user.FirstName) || e.PropertyName == nameof(user.LastName));

            if (relevantErrors.Any())
            {
                var errors = relevantErrors.Select(e => e.ErrorMessage).ToList();
                _logger.LogWarning("Validation failed for user profile update:\n{Errors}", string.Join("\n", errors));
                return Result.Failure<UserDTO, IEnumerable<string>>(relevantErrors.Select(e => e.ErrorMessage));
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;

            _userRepository.UpdateUser(existingUser);
            _logger.LogInformation("User profile updated (Id: {UserId})", userId);
            var usr = _mapper.Map<UserDTO>(existingUser);
            return Result.Success<UserDTO, IEnumerable<string>>(usr);
        }

        public async Task<Result<UserDTO, IEnumerable<string>>> UpdateUserPasswordAsync(Guid userId, User user)
        {
            _logger.LogInformation("Updating user password (ID: {UserId})", userId);
            var existingUser = _userRepository.GetUserById(userId);
            var errMessages = new List<string>();
            if (existingUser == null)
            {
                var errorMessage = string.Format("User (Id: {0}) does not exist", user.UserId);
                _logger.LogWarning(errorMessage);
                errMessages.Add(errorMessage);
                return Result.Failure<UserDTO, IEnumerable<string>>(errMessages);
            }

            var validationResult = _userValidator.Validate(user);
            var relevantErrors = validationResult.Errors.Where(e =>
                e.PropertyName == nameof(user.Password));

            if (relevantErrors.Any())
            {
                var errors = relevantErrors.Select(e => e.ErrorMessage).ToList();
                _logger.LogWarning("Validation failed for user password update:\n{Errors}", string.Join("\n", errors));
                return Result.Failure<UserDTO, IEnumerable<string>>(relevantErrors.Select(e => e.ErrorMessage));
            }

            bool newPasswordSameAsOld = _userRepository.VerifyPassword(user.Password, existingUser.Password, existingUser.Salt);
            if (user.Password != null && !newPasswordSameAsOld)
            {
                Tuple<string, string> newPassword = PasswordHelper.HashPassword(user.Password);
                existingUser.Password = newPassword.Item1;
                existingUser.Salt = newPassword.Item2;
            }

            _userRepository.UpdateUser(existingUser);
            _logger.LogInformation("User password updated (Id: {UserId})", userId);
            var usr = _mapper.Map<UserDTO>(existingUser);
            return Result.Success<UserDTO, IEnumerable<string>>(usr);
        }
    }
}
