using Microsoft.EntityFrameworkCore;
using ValconLibrary.Entities;

namespace ValconLibrary.Data.Repository.BookRents
{
    public class BookRentRepository : IBookRentRepository
    {
        private readonly LibraryContext _context;

        public BookRentRepository(LibraryContext context)
        {
            _context = context;
        }

        public void AddRent(BookRent rent)
        {
            _context.BookRents.Add(rent);
            _context.SaveChanges();
        }

        public int GetActiveRentsCount(Guid bookId)
        {
            return _context.BookRents.Count(rent => rent.BookId == bookId && rent.ReturnDate == null);
        }

        public BookRent GetActiveRent(Guid userId, Guid bookId)
        {
            return _context.BookRents
                .FirstOrDefault(r => r.UserId == userId
                && r.BookId == bookId && r.ReturnDate == null);
        }

        public void UpdateRent(BookRent rent)
        {
            _context.BookRents.Update(rent);
            _context.SaveChanges();
        }

        public List<BookRent> GetRentsByUserId(Guid userId)
        {
            return _context.BookRents
                .Include(u => u.User)
                .Include(b => b.Book)
                .Where(e => e.UserId == userId)
                .ToList();
        }

        public List<BookRent> GetRentsByBookId(Guid bookId)
        {
            return _context.BookRents
                .Include(u => u.User)
                .Include(b => b.Book)
                .Where(e => e.BookId == bookId)
                .ToList();
        }
    }
}
