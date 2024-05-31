using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ValconLibrary.Entities
{
    public class User
    {
        [Key]
        [Column("userId")]
        public Guid UserId { get; set; }

        [Column("firstName")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Column("lastName")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Column("role")]
        [StringLength(30)]
        public string Role { get; set; }

        [Column("email")]
        [StringLength(40)]
        public string Email { get; set; } 

        [Column("password")]
        [StringLength(1000)]
        public string Password { get; set; } 

        [Column("salt")]
        [StringLength(1000)]
        public string Salt { get; set; }


        public ICollection<BookRent> BookRents { get; set; }
    }
}
