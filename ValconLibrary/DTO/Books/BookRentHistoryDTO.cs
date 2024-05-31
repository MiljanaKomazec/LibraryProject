using ValconLibrary.Constants;

namespace ValconLibrary.DTO.Books
{
    public class BookRentHistoryDTO
    {
        public string Title { get; set; }

        public string ISBN { get; set; }

        public Genre Genre { get; set; }

        public int NumberOfPages { get; set; }

        public int PublishingYear { get; set; }

        public int TotalCopies { get; set; }
    }
}
