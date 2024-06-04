using GameStore.Domain.Genres;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Persistence.Genres.EntityFrameworkCore;

public static class GenreSeeder
{
    public static void SeedDefaultGenres(this ModelBuilder modelBuilder)
    {
        var strategyGenre = new Genre("RTS", null);
        var racesGenre = new Genre("Races", null);
        var actionGenre = new Genre("Action", null);

        modelBuilder.Entity<Genre>()
            .HasData(
                strategyGenre,
                new Genre("TBS", strategyGenre.Id),
                new Genre("RPG", null),
                new Genre("Sports", null),
                racesGenre,
                new Genre("Rally", racesGenre.Id),
                new Genre("Arcade", racesGenre.Id),
                new Genre("Formula", racesGenre.Id),
                new Genre("Off-road", racesGenre.Id),
                actionGenre,
                new Genre("FPS", actionGenre.Id),
                new Genre("TPS", actionGenre.Id),
                new Genre("Adventure", null),
                new Genre("Puzzle & Skill", null));
    }
}