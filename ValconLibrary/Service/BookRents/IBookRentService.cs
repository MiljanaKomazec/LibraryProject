using CSharpFunctionalExtensions;
using ValconLibrary.DTO.BookRents;
using ValconLibrary.Entities;

namespace ValconLibrary.Service.BookRents
{
    public interface IBookRentService
    {
        Task<Result<BookRentDTO, IEnumerable<string>>> RentBook(Guid userId, BookRentDTO bookRentDTO);
        Task<Result<BookReturnDTO, IEnumerable<string>>> ReturnBook(Guid userId, BookReturnDTO bookReturnDTO);
        Task<Result<List<RentHistoryUserDTO>, IEnumerable<string>>> GetRentsByUserId(Guid userId);
        Task<Result<List<RentHistoryBookDTO>, IEnumerable<string>>> GetRentsByBookId(Guid bookId);
    }
}
