using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ValconLibrary.Constants;
using ValconLibrary.DTO.Authors;
using ValconLibrary.DTO.BookRents;
using ValconLibrary.DTO.Books;
using ValconLibrary.Entities;
using ValconLibrary.Migrations;
using ValconLibrary.Service.Authors;
using ValconLibrary.Service.BookRents;
using ValconLibrary.Service.Books;

namespace ValconLibrary.Controllers
{
    [ApiController]
    [Authorize(Roles = LibraryRoles.Librarian)]
    [Route("api/books")]
    [Produces("application/json", "application/xml")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        private readonly IBookRentService _bookRentService;


        public BookController(IBookService bookService, IMapper mapper, IBookRentService bookRentService)
        {
            _bookService = bookService;
            _mapper = mapper;
            _bookRentService = bookRentService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<BookDTO>>> GetAllBooks()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<BookDTO>> GetBookById(Guid bookId)
        {
            var book = await _bookService.GetByIdAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookDTO>> CreateBook([FromForm] BookCreateDTO book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _bookService.CreateAsync(book);
            if (!result.IsSuccess)
            {
                var errorMessages = result.Error;
                return BadRequest(errorMessages);
            }
            return Created("", "Book created successfully.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BookDTO>> UpdateBook([FromBody] BookUpdateDTO bookUpdateDto)
        {
            var result = await _bookService.UpdateAsync(bookUpdateDto);
            if (!result.IsSuccess)
            {
                var errorMessages = result.Error;
                return BadRequest(errorMessages);
            }
            return Ok("Book updated successfully.");
        }

        [HttpDelete("{bookId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookDTO>> DeleteBook(Guid bookId)
        {
            var isDeleted = await _bookService.DeleteAsync(bookId);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok("Book successfully deleted.");
        }

        [Authorize(Roles = LibraryRoles.Librarian + " ," + LibraryRoles.Admin)]
        [HttpGet("{bookId}/rent-history")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<RentHistoryBookDTO>>> GetRentHistory(Guid bookId)
        {
            var rents = await _bookRentService.GetRentsByBookId(bookId);
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
