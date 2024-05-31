using System.ComponentModel.DataAnnotations;

namespace ValconLibrary.DTO.Users
{
    public class UserCreateDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
