using System.ComponentModel.DataAnnotations;

namespace ValconLibrary.Entities
{
    public class BookRent
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public DateTime RentDate { get; set; }
        public int RentalPeriodInDays { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}