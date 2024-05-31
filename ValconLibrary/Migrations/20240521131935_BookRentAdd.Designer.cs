﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValconLibrary.Data;

#nullable disable

namespace ValconLibrary.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20240521131935_BookRentAdd")]
    partial class BookRentAdd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("createdAt");

                    b.Property<string>("Genre")
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
                    b.Property<Guid>("BookRentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookRentId");

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
                            Password = "2OJf+YaCyIzhGrsxrmStga+2YXzSW5GjpiheXXjgKhjgcopdoZWePPy1AINqd+rI4dmiGcg6f2Kjwrl/i+pKeFrgpqhzQyLohEhKNhwqstu6U6Wg3ELYmpyrPLFfarNk35k94g5Sxqz/u+4rCkLGnIpHSRxAWCZ0/771nGzwD5Oph0b6Uqg+d4l5cuZrYi+Z6eurNpOXAWkmbuauo3ZRLXr7D85EY844f2JoGwmq/EryqCTNHh5oLzxPbUJjHIcbnPtAe8V7q5bhXKfNZI9nCoE5ijfY//1/U2XOf9csLlWr9KI69ZltDsC9TN81bMsZe8dXjr6Wr8U6yinY3tZtmQ==",
                            Role = "Admin",
                            Salt = "gMEBxVzFaXaf9w=="
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