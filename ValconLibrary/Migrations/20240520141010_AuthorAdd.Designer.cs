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
    [Migration("20240520141010_AuthorAdd")]
    partial class AuthorAdd
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
                            Password = "7LU03mmojijLVpbEjg33582G195H2Ar/RW0LXKuu3iPMBg4su+5n2jAPKOKUrCmkbz6MxoeQN5ROpUd0hgMtmPj+s33urhw/9vT+JBFG9UDPnokavYlT7KvQEziQ6leiULukQUACjlDGdcMX//PegfqrDsKqurbQD508B0WV+hig97K3WUJ6l6iJts3vLnQGeY8ujyt8i0vIPz4xMJ2tO4FZhg2qdHXt0UbJpToCqBnnPU7h6HJh2cyyIAY7+uBFYGSX/Pvvu0AlW/VAL1WkGDG3pf7yN+oxDN9yTz6cbKH8oCK4/brA4OSt2A/lDflQak8aBcGGU/REYXbsjhhq0w==",
                            Role = "Admin",
                            Salt = "DYVwLVgw3ElNzg=="
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
