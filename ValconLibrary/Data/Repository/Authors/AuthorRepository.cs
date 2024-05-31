using Microsoft.EntityFrameworkCore;
using ValconLibrary.DTO.Books;
using ValconLibrary.Entities;

namespace ValconLibrary.Data.Repository.Authors
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public List<Author> GetAll()
        {
            return _context.Authors.Where(a => !a.IsDeleted).ToList();
        }

        public Author GetById(Guid AuthorId)
        {
            return _context.Authors.FirstOrDefault(e => e.AuthorId == AuthorId && !e.IsDeleted);
        }

        public Author Create(Author author)
        {
            author.CreatedAt = DateTime.UtcNow;
            author.ModifiedAt = null;
            author.IsDeleted = false;
            var createdEntity = _context.Add(author);
            _context.SaveChanges();
            return createdEntity.Entity;
        }

        public void Update(Author author)
        {
            author.ModifiedAt = DateTime.UtcNow;
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public bool Delete(Guid authorId)
        {
            var author = GetById(authorId);
            if (author == null)
            {
                return false;
            }
            author.IsDeleted = true;
            author.ModifiedAt = DateTime.UtcNow;
            _context.SaveChanges();
            return true;
        }

        public async Task<List<Author>> GetAuthors(List<Guid> authorsId)
        {
            return await _context.Authors
                                .Where(a => authorsId.Contains(a.AuthorId))
                                .ToListAsync();
        }
    }
}
