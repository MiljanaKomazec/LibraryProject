using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using ValconLibrary.Entities;
using ValconLibrary.Migrations;

namespace ValconLibrary.Data.Repository.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books
            .Include(b => b.Authors)
            .Where(b => !b.IsDeleted)
            .ToListAsync();
        }

        public async Task<Book> GetByIdAsync(Guid bookId)
        {
            return await _context.Books
            .Include(b => b.Authors)
            .FirstOrDefaultAsync(b => b.BookId == bookId && !b.IsDeleted);
        }

        public async Task CreateAsync(Book book)
        {
            book.CreatedAt = DateTime.UtcNow;
            book.ModifiedAt = null;
            book.IsDeleted = false;
            _context.Add(book);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Book book)
        {
            book.ModifiedAt = DateTime.UtcNow;
            _context.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid bookId)
        {
            var book = await GetByIdAsync(bookId);
            if (book == null)
            {
                return false;
            }
            book.IsDeleted = true;
            book.ModifiedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
