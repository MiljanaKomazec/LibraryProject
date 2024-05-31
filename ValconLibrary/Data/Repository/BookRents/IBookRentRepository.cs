using ValconLibrary.Entities;

namespace ValconLibrary.Data.Repository.BookRents
{
    public interface IBookRentRepository
    {
        void AddRent(BookRent rent);
        BookRent GetActiveRent(Guid userId, Guid bookId);
        void UpdateRent(BookRent rent);
        int GetActiveRentsCount(Guid bookId);
        List<BookRent> GetRentsByUserId(Guid userId);
        List<BookRent> GetRentsByBookId(Guid bookId);
    }
}
