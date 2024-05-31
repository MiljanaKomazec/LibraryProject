using System.ComponentModel.DataAnnotations.Schema;
using ValconLibrary.Constants;
using ValconLibrary.DTO.Authors;
using ValconLibrary.Entities;

namespace ValconLibrary.DTO.Books
{
    public class BookDTO
    {
        public string Title { get; set; }

        public string ISBN { get; set; }

        public Genre Genre { get; set; }

        public int NumberOfPages { get; set; }

        public int PublishingYear { get; set; }

        public int TotalCopies { get; set; }
        public string CoverImage { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public List<AuthorDTO> Authors { get; set; }
    }
}
