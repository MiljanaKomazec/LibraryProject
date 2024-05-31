using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json.Serialization;

namespace ValconLibrary.Entities
{
    public class Author
    {
        [Key]
        [Column("authorId")]
        public Guid AuthorId { get; set; }

        [Column("firstName")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Column("lastName")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Column("yearOfBirth", TypeName = "int")]
        public int YearOfBirth { get; set; }

        [Column("createdAt", TypeName = "date")]
        public DateTime CreatedAt { get; set; }

        [Column("modifiedAt", TypeName = "date")]
        public DateTime? ModifiedAt { get; set; }

        [Column("isDeleted")]
        public bool IsDeleted { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}