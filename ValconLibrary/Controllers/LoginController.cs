using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ValconLibrary.Authentication;

namespace ValconLibrary.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationHelper _authenticationHelper;

        public LoginController(IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
        }

        [AllowAnonymous]
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Login(Principal principal)
        {
            if (_authenticationHelper.AuthenticationPrincipal(principal))
            {
                var tokenString = _authenticationHelper.GenerateJwt(principal);
                return Ok(new { token = tokenString });
            }

            return NotFound("User not found");
        }
    }
}
