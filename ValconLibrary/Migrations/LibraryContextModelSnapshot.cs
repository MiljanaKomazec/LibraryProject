﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValconLibrary.Data;

#nullable disable

namespace ValconLibrary.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("ValconLibrary.Entities.Author", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("authorId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("date")
                        .HasColumnName("createdAt");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("firstName");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("isDeleted");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("lastName");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("date")
                        .HasColumnName("modifiedAt");

                    b.Property<int>("YearOfBirth")
                        .HasColumnType("int")
                        .HasColumnName("yearOfBirth");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("ValconLibrary.Entities.Book", b =>
                {
                    b.Property<Guid>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("bookId");

                    b.Property<string>("CoverImage")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("coverImage");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdAt");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("genre");

                    b.Property<string>("ISBN")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ISBN");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("isDeleted");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("modifiedAt");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int")
                        .HasColumnName("numberOfPages");

                    b.Property<int>("PublishingYear")
                        .HasColumnType("int")
                        .HasColumnName("publishingYear");

                    b.Property<string>("Title")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("title");

                    b.Property<int>("TotalCopies")
                        .HasColumnType("int")
                        .HasColumnName("totalCopies");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ValconLibrary.Entities.BookRent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RentalPeriodInDays")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookRents");
                });

            modelBuilder.Entity("ValconLibrary.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("userId");

                    b.Property<string>("Email")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("lastName");

                    b.Property<string>("Password")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("role");

                    b.Property<string>("Salt")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("salt");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                            Email = "admin@valcon.com",
                            FirstName = "Valcon",
                            LastName = "Admin",
                            Password = "A4fqqmiyR+Wg14mla/M3ZJGQtBgJqDR1rXUnHkSEIXVNjXCWf5YKXnWVhQRmjEoTVJwxy74RTN6oF8FKoAh0uKilaD9I0O1TMvtMc2ylpGSdEArI44o6XbZSftF46OZsDlT4ExBDtVb6UH/0A32ii83mB3qREGiYhSADqvnGzKXEN7kWQ4PJJ3TNlBbsuErIJ7Ww3ilcBwvN6/+/QVKWenY9CQLzHmxdNPuqq86/wCdfynkefSUmBAjoPe5y7z4YOdk6DFGEvCTvGIP3936o1QEa1QZpmEQ12uKGLDTRldV33cjkldRRgpBUckex6fLK5CqwkVJckwVC4faZ4Ok0Hg==",
                            Role = "Admin",
                            Salt = "WC0vyVfzZH21LQ=="
                        });
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("ValconLibrary.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ValconLibrary.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ValconLibrary.Entities.BookRent", b =>
                {
                    b.HasOne("ValconLibrary.Entities.Book", "Book")
                        .WithMany("BookRents")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ValconLibrary.Entities.User", "User")
                        .WithMany("BookRents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ValconLibrary.Entities.Book", b =>
                {
                    b.Navigation("BookRents");
                });

            modelBuilder.Entity("ValconLibrary.Entities.User", b =>
                {
                    b.Navigation("BookRents");
                });
#pragma warning restore 612, 618
        }
    }
}
