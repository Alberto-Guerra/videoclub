﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Videoclub.API.Context;

#nullable disable

namespace Videoclub.API.Migrations
{
    [DbContext(typeof(VideoclubContext))]
    [Migration("20230929103158_MovieSeeding")]
    partial class MovieSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Videoclub.API.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Thriller"
                        });
                });

            modelBuilder.Entity("Videoclub.API.Model.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Available")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhotoURL")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Available = true,
                            CategoryId = 3,
                            Description = "Some people are in prison and they try to scape",
                            PhotoURL = "https://m.media-amazon.com/images/M/MV5BNDE3ODcxYzMtY2YzZC00NmNlLWJiNDMtZDViZWM2MzIxZDYwXkEyXkFqcGdeQXVyNjAwNDUxODI@._V1_FMjpg_UX1000_.jpg",
                            Title = "The Shawshank Redemption"
                        },
                        new
                        {
                            Id = 2,
                            Available = true,
                            CategoryId = 1,
                            Description = "Oscar DiCaprio is in the woods and he is cold",
                            PhotoURL = "https://m.media-amazon.com/images/M/MV5BMDE5OWMzM2QtOTU2ZS00NzAyLWI2MDEtOTRlYjIxZGM0OWRjXkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_.jpg",
                            Title = "The Revenant"
                        },
                        new
                        {
                            Id = 3,
                            Available = true,
                            CategoryId = 3,
                            Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                            PhotoURL = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg",
                            Title = "The Godfather"
                        },
                        new
                        {
                            Id = 4,
                            Available = true,
                            CategoryId = 1,
                            Description = "Some guys fight",
                            PhotoURL = "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg",
                            Title = "Fight Club"
                        });
                });

            modelBuilder.Entity("Videoclub.API.Model.RentHistory", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserId", "MovieId", "RentDate");

                    b.HasIndex("MovieId");

                    b.ToTable("RentHistories");
                });

            modelBuilder.Entity("Videoclub.API.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Videoclub.API.Model.Movie", b =>
                {
                    b.HasOne("Videoclub.API.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Videoclub.API.Model.RentHistory", b =>
                {
                    b.HasOne("Videoclub.API.Model.Movie", "Movie")
                        .WithMany("RentHistories")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Videoclub.API.Model.User", "User")
                        .WithMany("RentHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Videoclub.API.Model.Movie", b =>
                {
                    b.Navigation("RentHistories");
                });

            modelBuilder.Entity("Videoclub.API.Model.User", b =>
                {
                    b.Navigation("RentHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
