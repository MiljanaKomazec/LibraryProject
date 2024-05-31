using CSharpFunctionalExtensions;
using ValconLibrary.DTO.Books;
using ValconLibrary.Entities;

namespace ValconLibrary.Service.Books
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllAsync();
        Task<BookDTO> GetByIdAsync(Guid bookId);
        Task<Result<BookDTO, IEnumerable<string>>> CreateAsync(BookCreateDTO book);
        Task<Result<BookDTO, IEnumerable<string>>> UpdateAsync(BookUpdateDTO bookUpdateDTO);
        Task<bool> DeleteAsync(Guid bookId);
    }
}
