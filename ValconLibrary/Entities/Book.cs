using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ValconLibrary.Constants;

namespace ValconLibrary.Entities
{
    public class Book
    {
        [Key]
        [Column("bookId")]
        public Guid BookId { get; set; }

        [Column("title")]
        [StringLength(60)]
        public string Title { get; set; }

        [Column("ISBN")]
        [StringLength(20)]
        public string ISBN { get; set; }

        [Column("genre")]
        [StringLength(60)]
        public Genre Genre { get; set; }

        [Column("numberOfPages")]
        public int NumberOfPages { get; set; }

        [Column("publishingYear")]
        public int PublishingYear { get; set; }

        [Column("totalCopies")]
        public int TotalCopies { get; set; }

        [Column("coverImage")]
        [StringLength(100)]
        public string CoverImage { get; set; }

        [Column("createdAt")]
        public DateTime CreatedAt { get; set; }

        [Column("modifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [Column("isDeleted")]
        public bool IsDeleted { get; set; }


        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public ICollection<BookRent> BookRents { get; set; }
    }
}