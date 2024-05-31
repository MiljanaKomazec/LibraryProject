using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Reflection.Emit;
using ValconLibrary.Entities;
using ValconLibrary.Helpers;

namespace ValconLibrary.Data
{
    public class LibraryContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public LibraryContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRent> BookRents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var password = PasswordHelper.HashPassword("passworD1!");
            builder.Entity<User>()
                .HasData(new
                {
                    UserId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    FirstName = "Valcon",
                    LastName = "Admin",
                    Email = "admin@valcon.com",
                    Role = "Admin",
                    Password = password.Item1,
                    Salt = password.Item2
                });

            builder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithMany(b => b.Authors)
            .UsingEntity<Dictionary<string, object>>(
                "AuthorBook",
                ab => ab.HasOne<Book>().WithMany().HasForeignKey("BookId"),
                ab => ab.HasOne<Author>().WithMany().HasForeignKey("AuthorId"));

            builder.Entity<Book>()
            .Property(b => b.Genre)
            .HasConversion<string>();

            builder.Entity<BookRent>()
                .HasOne(r => r.User)
                .WithMany(u => u.BookRents)
                .HasForeignKey(r => r.UserId);

            builder.Entity<BookRent>()
                .HasOne(r => r.Book)
                .WithMany(b => b.BookRents)
                .HasForeignKey(r => r.BookId);
        }
    }
}
