using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ValconLibrary.Constants;
using ValconLibrary.DTO.Authors;
using ValconLibrary.DTO.BookRents;
using ValconLibrary.DTO.Users;
using ValconLibrary.Entities;
using ValconLibrary.Service.BookRents;
using ValconLibrary.Service.Users;

namespace ValconLibrary.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Produces("application/json", "application/xml")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IBookRentService _bookRentService;

        public UsersController(IUserService userService, IMapper mapper, 
            IBookRentService bookRentService) 
        {
            _userService = userService;
            _mapper = mapper;
            _bookRentService = bookRentService;
        }

        [Authorize(Roles = LibraryRoles.Admin)]
        [HttpPost("librarian")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> CreateLibrarian([FromBody] UserCreateDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User mappedUser = _mapper.Map<User>(user);
            mappedUser.Role = LibraryRoles.Librarian;
            var result = await _userService.Create(mappedUser);
            if (!result.IsSuccess)
            {
                var errorMessages = result.Error;
                return BadRequest(errorMessages);
            }
            return Created("", "Librarian created successfully.");
        }

        [Authorize(Roles = LibraryRoles.Librarian)]
        [HttpPost("member")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserCreateDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User mappedUser = _mapper.Map<User>(user);
            mappedUser.Role = LibraryRoles.User;
            var result = await _userService.Create(mappedUser);
            if (!result.IsSuccess)
            {
                var errorMessages = result.Error;
                return BadRequest(errorMessages);
            }
            return Created("", "Member created successfully.");
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<UserDTO>> GetAllUsers([FromQuery] string role)
        {
            var users = _userService.GetAll(role);
            return Ok(users);
        }

        [Authorize(Roles = LibraryRoles.Librarian)]
        [HttpPost("{userId}/rent-book")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RentBook(Guid userId, [FromBody] BookRentDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _bookRentService.RentBook(userId, request);
            if (!result.IsSuccess)
            {
                var errorMessages = result.Error;
                return BadRequest(errorMessages);
            }
            return Ok("Book rented successfully");
        }

        [Authorize(Roles = LibraryRoles.Librarian)]
        [HttpPost("{userId}/return-book")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ReturnBook(Guid userId, [FromBody] BookReturnDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _bookRentService.ReturnBook(userId, request);
            if (!result.IsSuccess)
            {
                var errorMessages = result.Error;
                return BadRequest(errorMessages);
            }
            return Ok("Book returned successfully");
        }

        [Authorize(Roles = LibraryRoles.Librarian)]
        [HttpGet("{userId}/rent-history")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<RentHistoryUserDTO>>> GetRentHistory(Guid userId)
        {
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
