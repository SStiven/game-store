﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartShop.Infrastructure.Persistance.Common.EntityFrameworkCore;

#nullable disable

namespace GameStore.Persistence.Common.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(GameStoreSqlServerDbContext))]
    [Migration("20240604230815_RefactorGenreSeeder")]
    partial class RefactorGenreSeeder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameStore.Domain.Games.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("description");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(105)
                        .HasColumnType("nvarchar(105)")
                        .HasColumnName("key");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Key")
                        .IsUnique();

                    b.ToTable("game", (string)null);
                });

            modelBuilder.Entity("GameStore.Domain.Games.GameGenre", b =>
                {
                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("game_id");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("genre_id");

                    b.HasKey("GameId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("game_genre", (string)null);
                });

            modelBuilder.Entity("GameStore.Domain.Games.GamePlatform", b =>
                {
                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("game_id");

                    b.Property<Guid>("PlatformId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("platform_id");

                    b.HasKey("GameId", "PlatformId");

                    b.HasIndex("PlatformId");

                    b.ToTable("game_platform", (string)null);
                });

            modelBuilder.Entity("GameStore.Domain.Genres.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<Guid?>("ParentGenreId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("parent_genre_id");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ParentGenreId");

                    b.ToTable("genre", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("a6e691da-65cc-43ad-a1a1-776db0f427d4"),
                            Name = "RTS"
                        },
                        new
                        {
                            Id = new Guid("d360ef8a-8272-4d7a-9797-0cb117cab398"),
                            Name = "TBS",
                            ParentGenreId = new Guid("a6e691da-65cc-43ad-a1a1-776db0f427d4")
                        },
                        new
                        {
                            Id = new Guid("1336a4e6-e3ca-4fd4-bfc6-8b67c9e56194"),
                            Name = "RPG"
                        },
                        new
                        {
                            Id = new Guid("6bc24937-2beb-41b7-a95f-7c00aa5d5228"),
                            Name = "Sports"
                        },
                        new
                        {
                            Id = new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555"),
                            Name = "Races"
                        },
                        new
                        {
                            Id = new Guid("6b13972d-fbd9-4a7f-9e2a-d98bfd452840"),
                            Name = "Rally",
                            ParentGenreId = new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555")
                        },
                        new
                        {
                            Id = new Guid("1ecc7b7f-fd52-4182-9716-468ac5f8695a"),
                            Name = "Arcade",
                            ParentGenreId = new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555")
                        },
                        new
                        {
                            Id = new Guid("f4ed662f-f1e9-4e17-a6d7-46b9371bbd57"),
                            Name = "Formula",
                            ParentGenreId = new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555")
                        },
                        new
                        {
                            Id = new Guid("bd8a7bed-5979-4600-bda4-757a93cd2771"),
                            Name = "Off-road",
                            ParentGenreId = new Guid("46425451-d1d5-44e9-8c60-29a2d4a31555")
                        },
                        new
                        {
                            Id = new Guid("fffd3f7c-77c2-4d03-85fe-f945a946ac9a"),
                            Name = "Action"
                        },
                        new
                        {
                            Id = new Guid("7bb18dd0-453c-4ad2-8028-fc9619032dde"),
                            Name = "FPS",
                            ParentGenreId = new Guid("fffd3f7c-77c2-4d03-85fe-f945a946ac9a")
                        },
                        new
                        {
                            Id = new Guid("70a73e9f-9b73-4740-bdca-2b1408cfda03"),
                            Name = "TPS",
                            ParentGenreId = new Guid("fffd3f7c-77c2-4d03-85fe-f945a946ac9a")
                        },
                        new
                        {
                            Id = new Guid("bcf4ec2a-ef6e-4167-9bc2-bca7b7f5d3a9"),
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = new Guid("8282fc45-5d9b-4e48-abd7-b66f5c471361"),
                            Name = "Puzzle & Skill"
                        });
                });

            modelBuilder.Entity("GameStore.Domain.Platforms.Platform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("platform", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("e5bd3bec-2c19-4672-9f15-cd47aa277bfe"),
                            Type = "Mobile"
                        },
                        new
                        {
                            Id = new Guid("578e223f-82da-4c58-99c2-219e72ddba19"),
                            Type = "Browser"
                        },
                        new
                        {
                            Id = new Guid("027eec94-73fd-4d04-8219-2a63b8d85cca"),
                            Type = "Desktop"
                        },
                        new
                        {
                            Id = new Guid("22f409cd-f783-4738-9875-e520d5c62d42"),
                            Type = "Console"
                        });
                });

            modelBuilder.Entity("GameStore.Domain.Games.GameGenre", b =>
                {
                    b.HasOne("GameStore.Domain.Games.Game", "Game")
                        .WithMany("GameGenres")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GameStore.Domain.Genres.Genre", "Genre")
                        .WithMany("GameGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("GameStore.Domain.Games.GamePlatform", b =>
                {
                    b.HasOne("GameStore.Domain.Games.Game", "Game")
                        .WithMany("GamePlatforms")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GameStore.Domain.Platforms.Platform", "Platform")
                        .WithMany("GamePlatforms")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("GameStore.Domain.Genres.Genre", b =>
                {
                    b.HasOne("GameStore.Domain.Genres.Genre", "ParentGenre")
                        .WithMany("SubGenres")
                        .HasForeignKey("ParentGenreId");

                    b.Navigation("ParentGenre");
                });

            modelBuilder.Entity("GameStore.Domain.Games.Game", b =>
                {
                    b.Navigation("GameGenres");

                    b.Navigation("GamePlatforms");
                });

            modelBuilder.Entity("GameStore.Domain.Genres.Genre", b =>
                {
                    b.Navigation("GameGenres");

                    b.Navigation("SubGenres");
                });

            modelBuilder.Entity("GameStore.Domain.Platforms.Platform", b =>
                {
                    b.Navigation("GamePlatforms");
                });
#pragma warning restore 612, 618
        }
    }
}