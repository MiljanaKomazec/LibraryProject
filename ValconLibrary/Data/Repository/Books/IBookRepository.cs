using ValconLibrary.Entities;

namespace ValconLibrary.Data.Repository.Books
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(Guid bookId);
        Task CreateAsync(Book book);
        Task UpdateAsync(Book book);
        Task<bool> DeleteAsync(Guid bookId);
    }
}
