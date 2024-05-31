using ValconLibrary.DTO.Books;
using ValconLibrary.DTO.Users;

namespace ValconLibrary.DTO.BookRents
{
    public class RentHistoryBookDTO
    {
        public UserRentHistoryDTO User { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
