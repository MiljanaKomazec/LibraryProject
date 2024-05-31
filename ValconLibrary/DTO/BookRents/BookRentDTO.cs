using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ValconLibrary.DTO.BookRents
{
    public class BookRentDTO
    {
        public Guid BookId { get; set; }

        public DateTime? RentDate { get; set; }

        public int RentalPeriodInDays { get; set; }
    }
}
