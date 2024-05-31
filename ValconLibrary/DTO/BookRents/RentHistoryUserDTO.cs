using ValconLibrary.DTO.Authors;
using ValconLibrary.DTO.Books;
using ValconLibrary.DTO.Users;

namespace ValconLibrary.DTO.BookRents
{
    public class RentHistoryUserDTO
    {
        public BookRentHistoryDTO Book { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
