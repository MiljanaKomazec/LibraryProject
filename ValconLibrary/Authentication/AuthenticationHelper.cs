using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ValconLibrary.Data.Repository.Users;

namespace ValconLibrary.Authentication
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthenticationHelper> _logger;

        public AuthenticationHelper(
            IConfiguration configuration, 
            IUserRepository userRepository, 
            ILogger<AuthenticationHelper> logger)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _logger = logger;
        }

        public bool AuthenticationPrincipal(Principal principal)
        {
            return _userRepository.UserWithCredentialsExists(principal.Email, principal.Password);
        }

        public string GenerateJwt(Principal principal)
        {
            _logger.LogInformation("Generating JWT (Email: {Email})", principal.Email);
            var user = _userRepository.GetByEmail(principal.Email);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
               new Claim(ClaimTypes.Role, user.Role),
               new Claim(ClaimTypes.Email, user.Email),
               new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                             _configuration["Jwt:Audience"],
                                             claims,
                                             expires: DateTime.UtcNow.AddMinutes(20),
                                             signingCredentials: credentials);

            _logger.LogInformation("JWT generated Email: {Email}", principal.Email);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
