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
    [Migration("20240517101406_UserToUsers")]
    partial class UserToUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                            Password = "LG6fHCan3NnpzBrWiBJebC/WQcKI8jTwZ+zM5/HBITlN5CuTK5+Zdcy4ILEWl+tVjLUn6esa8AkVW1j2O1/FuDXYxqWKKnOcF8Soy+eMFCzzJQBYSAyJiyMyR/PYw8hQH7HpjLxdXNZ1dF+IIpFMEiaR8hve0MQgP0VZVLrc8ZcyoOw/n2FPUdKRNnMFTR7jBvzq+W4zh/ADubWEjFN+klgaIqSNZ6wS+SKYh9LSOCv05mX3GtHkTydyopqIaiI4ajSUIuplkpzRkF9uUPDQMGRm2x/MrXmvU1UVm6Uw219b6TD6JdIa1pvkghHqVNIZJvo0YmDKHYOCODbSaWDbSg==",
                            Role = "Admin",
                            Salt = "NQJATijgMAkZvw=="
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
