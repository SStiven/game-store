using GameStore.Domain.Platforms;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Persistence.EntityFrameworkCore.Seeders;

public static class PlatformSeeder
{
    public static void SeedDefaultPlaforms(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Platform>()
        .HasData(
            new Platform("Mobile"),
            new Platform("Browser"),
            new Platform("Desktop"),
            new Platform("Console"));
    }
}