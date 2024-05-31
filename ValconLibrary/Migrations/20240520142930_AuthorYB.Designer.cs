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
    [Migration("20240520142930_AuthorYB")]
    partial class AuthorYB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<decimal>("YearOfBirth")
                        .HasColumnType("numeric(4, 0)")
                        .HasColumnName("yearOfBirth");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
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
                            Password = "mDJzDcObp/ZekIbdVNCcafluOj74O2odqUQb4gX8zNBNuZw+9tQKMFcN4W+ZJZMhMYtRVVQ+doigEf6EX+nk8lTfYUX20cTv56kgmw3LjywcXyxl2mX1gARdZhy+vXWtSRljFfDTcOgfcjIqHQLdfr04szfc82zsx8q/p6cb8PPH3mDvcA5Tv6MUodPnIeMihQJZu1bWeRSZxxGiPS6lEYMpqHpabdxDx+moQUCl38/taeYlGqBibYHrMMOw0ffDGWJ2x4flYv3H3VBzkgk1coDAW+29A+RIciYB13BlsNBBZoAp9SgdtNE+od3SnU5lLpOW1jnTYpEAXdCaDg47Dw==",
                            Role = "Admin",
                            Salt = "LtUmkkkMuS1wnQ=="
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
