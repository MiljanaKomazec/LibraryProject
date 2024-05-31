using System.Data;

namespace ValconLibrary.DTO.Authors
{
    public class AuthorDTO
    {
        public Guid AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int YearOfBirth { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set;}
    }
}
