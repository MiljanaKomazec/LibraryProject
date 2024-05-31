using AutoMapper;
using System.Security.Cryptography;
using ValconLibrary.Entities;
using ValconLibrary.Migrations;

namespace ValconLibrary.Data.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryContext _context;

        public UserRepository(LibraryContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            var createdEntity = _context.Add(user);
            _context.SaveChanges();
            return createdEntity.Entity;
        }

        public User GetByEmail(string email)
        {
            return _context.Users
                .FirstOrDefault(e => e.Email == email);
        }

        public bool EmailExists(string email)
        {
            User user = _context.Users
                .FirstOrDefault(e => e.Email == email);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public bool UserWithCredentialsExists(string email, string password)
        {
            User user = _context.Users
                .FirstOrDefault(e => e.Email == email);
            if (user == null)
            {
                return false;
            }

            if (VerifyPassword(password, user.Password, user.Salt))
            {
                return true;
            }
            return false;
        }

        public bool VerifyPassword(string password, string savedHash, string savedSalt)
        {
            int iterations = 1000;
            var saltBytes = Convert.FromBase64String(savedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, iterations);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == savedHash;
        }

        public List<User> GetAll(string role)
        {
            return _context.Users
                .Where(e => e.Role == role)
                .ToList();
        }

        public User GetUserById(Guid UserId)
        {
            return _context.Users
                .FirstOrDefault(e => e.UserId == UserId);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
