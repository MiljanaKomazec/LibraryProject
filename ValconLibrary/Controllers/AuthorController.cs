using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ValconLibrary.Constants;
using ValconLibrary.DTO.Authors;
using ValconLibrary.DTO.Users;
using ValconLibrary.Entities;
using ValconLibrary.Service.Authors;
using ValconLibrary.Service.Users;

namespace ValconLibrary.Controllers
{
    [ApiController]
    [Route("api/authors")]
    [Authorize(Roles = LibraryRoles.Librarian)]
    [Produces("application/json", "application/xml")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<AuthorDTO>> GetAllAuthors()
        {
            var authors = _authorService.GetAll();
            return Ok(authors);
        }

        [HttpGet("{authorId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<AuthorDTO> GetAuthorById(Guid authorId)
        {
            var author = _authorService.GetById(authorId);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AuthorDTO>> CreateAuthor([FromBody] AuthorCreateDTO author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authorService.Create(author);
            if (!result.IsSuccess)
            {
                var errorMessages = result.Error;
                return BadRequest(errorMessages);
            }
            return Created("", "Author created successfully.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AuthorDTO>> UpdateAuthor([FromBody] AuthorUpdateDTO authorUpdateDto)
        {
            var result = await _authorService.Update(authorUpdateDto);
            if (!result.IsSuccess)
            {
                var errorMessages = result.Error;
                return BadRequest(errorMessages);
            }
            return Ok("Author updated successfully.");
        }

        [HttpDelete("{authorId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AuthorDTO> DeleteAuthor(Guid authorId)
        {
            var isDeleted = _authorService.Delete(authorId);
            if(!isDeleted)
            {
                return NotFound();
            }
            return Ok("Author successfully deleted.");
        }
    }
}
