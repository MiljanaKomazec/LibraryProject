using ValconLibrary.Entities;

namespace ValconLibrary.Data.Repository.Users
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetByEmail(string email);
        List<User> GetAll(string role);
        User GetUserById(Guid UserId);
        void UpdateUser(User user);
        bool EmailExists(string email);
        bool UserWithCredentialsExists(string email, string password);
        bool VerifyPassword(string password, string savedHash, string savedSalt);
    }
}
