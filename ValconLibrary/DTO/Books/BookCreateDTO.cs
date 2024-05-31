using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ValconLibrary.Constants;

namespace ValconLibrary.DTO.Books
{
    public class BookCreateDTO
    {
        public string Title { get; set; }

        public string ISBN { get; set; }

        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }

        public int NumberOfPages { get; set; }

        public int PublishingYear { get; set; }

        public int TotalCopies { get; set; }
        public IFormFile CoverImage { get; set; }

        public List<Guid> AuthorIds { get; set; }
    }
}
