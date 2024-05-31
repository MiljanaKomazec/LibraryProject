using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ValconLibrary.Constants;
using ValconLibrary.DTO.BookRents;
using ValconLibrary.DTO.Users;
using ValconLibrary.Entities;
using ValconLibrary.Service.BookRents;
using ValconLibrary.Service.Users;

namespace ValconLibrary.Controllers
{
    [ApiController]
    [Route("api/profile")]
    [Produces("application/json", "application/xml")]
    public class ProfileController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IBookRentService _bookRentService;
        private readonly IMapper _mapper;

        public ProfileController(IUserService userService, IMapper mapper, IBookRentService bookRentService)
        {
            _userService = userService;
            _mapper = mapper;
            _bookRentService = bookRentService;
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> UpdateUserProfile([FromBody] UserUpdateProfileDTO userUpdateDto)
        {
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            {
                return Unauthorized();
            }
            User mappedUser = _mapper.Map<User>(userUpdateDto);
            var result = await _userService.UpdateUserProfileAsync(userId, mappedUser);
            if (!result.IsSuccess)
            {
                var errorMessages = result.Error;
                return BadRequest(errorMessages);
            }
            return Ok("User profile updated successfully.");
        }

        [HttpPut("password")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> UpdateUserPassword([FromBody] UserUpdatePasswordDTO userUpdateDto)
        {
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            {
                return Unauthorized();
            }
            User mappedUser = _mapper.Map<User>(userUpdateDto);
            var result = await _userService.UpdateUserPasswordAsync(userId, mappedUser);
            if (!result.IsSuccess)
            {
                var errorMessages = result.Error;
                return BadRequest(errorMessages);
            }
            return Ok("User password updated successfully.");
        }

        [Authorize(Roles = LibraryRoles.User)]
        [HttpGet("rent-history")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<RentHistoryUserDTO>>> GetRentHistory()
        {
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            {
                return Unauthorized();
            }
            var rents = await _bookRentService.GetRentsByUserId(userId);
            if (!rents.IsSuccess)
            {
                var errorMessages = rents.Error;
                return BadRequest(errorMessages);
            }
            var rentData = rents.Value;
            return Ok(rentData);
        }
    }
}
