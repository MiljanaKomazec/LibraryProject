using ValconLibrary.Constants;
using ValconLibrary.Entities;

namespace ValconLibrary.DTO.Books
{
    public class BookUpdateDTO
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }

        public Genre Genre { get; set; }

        public int PublishingYear { get; set; }

        public int TotalCopies { get; set; }
        public List<Guid> AuthorIds { get; set; }
    }
}
