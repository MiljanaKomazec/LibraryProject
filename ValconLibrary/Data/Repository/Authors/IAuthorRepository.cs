using ValconLibrary.DTO.Books;
using ValconLibrary.Entities;

namespace ValconLibrary.Data.Repository.Authors
{
    public interface IAuthorRepository
    {
        List<Author> GetAll();
        Author GetById(Guid AuthorId);
        Author Create(Author author);
        void Update(Author author);
        bool Delete(Guid authorId);
        Task<List<Author>> GetAuthors(List<Guid> authorsId);
    }
}
