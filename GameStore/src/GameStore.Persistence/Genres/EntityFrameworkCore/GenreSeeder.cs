using GameStore.Domain.Genres;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Persistence.Genres.EntityFrameworkCore;

public static class GenreSeeder
{
    public static void SeedDefaultGenres(this ModelBuilder modelBuilder)
    {
        var strategyGuid = new Guid("e9b6c311-ff9e-47ce-bf47-89c64a1ea2ed");
        var racesGuid = new Guid("7c7e700e-7bdc-4d99-9eeb-6389604ee3e4");
        var actionGuid = new Guid("788645ae-ea06-4013-8664-11d3cedcf756");

        modelBuilder.Entity<Genre>()
            .HasData(
                new Genre
                {
                    Name = "Strategy",
                    Id = strategyGuid,
                },
                new Genre
                {
                    Name = "RTS",
                    Id = new Guid("0bc9b264-ea4e-4842-9ce1-cdbc6e48aac3"),
                    ParentGenreId = strategyGuid,
                },
                new Genre
                {
                    Name = "TBS",
                    Id = new Guid("eb714918-05ad-49e0-b1c4-1551e2e45f63"),
                    ParentGenreId = strategyGuid,
                },
                new Genre
                {
                    Name = "RPG",
                    Id = new Guid("539a11e6-ef8e-4718-a0b7-7a9ea7594645"),
                },
                new Genre
                {
                    Name = "Sports",
                    Id = new Guid("566151a8-9412-4731-9ac7-d97efcd829fd"),
                },
                new Genre
                {
                    Name = "Races",
                    Id = racesGuid,
                },
                new Genre
                {
                    Name = "Rally",
                    Id = new Guid("69380ec4-0926-4a41-8a47-c57ec407d4d7"),
                    ParentGenreId = racesGuid,
                },
                new Genre
                {
                    Name = "Arcade",
                    Id = new Guid("c92f983e-7ae1-4b4a-b269-d7bd0008ae85"),
                    ParentGenreId = racesGuid,
                },
                new Genre
                {
                    Name = "Formula",
                    Id = new Guid("4d97b2ce-13e6-4950-923b-715689f4ff38"),
                    ParentGenreId = racesGuid,
                },
                new Genre
                {
                    Name = "Off-road",
                    Id = new Guid("015b74ba-68ab-4b11-bab5-3399bccbff1f"),
                    ParentGenreId = racesGuid,
                },
                new Genre
                {
                    Name = "Action",
                    Id = actionGuid,
                },
                new Genre
                {
                    Name = "FPS",
                    Id = new Guid("7245fed8-4802-4668-9732-37b19b3f853e"),
                    ParentGenreId = actionGuid,
                },
                new Genre
                {
                    Name = "TPS",
                    Id = new Guid("d1951207-eb9b-4c24-b32a-3b751275376b"),
                    ParentGenreId = actionGuid,
                },
                new Genre
                {
                    Name = "Adventure",
                    Id = new Guid("47a196b1-f734-4cda-b8f1-55eeade8c3f8"),
                },
                new Genre
                {
                    Name = "Puzzle & Skill",
                    Id = new Guid("4f17398d-7316-4ddb-8001-498dac4a0642"),
                });
    }
}