namespace ValconLibrary.DTO.Authors
{
    public class AuthorUpdateDTO
    {
        public Guid AuthorId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int YearOfBirth { get; set; }
    }
}
