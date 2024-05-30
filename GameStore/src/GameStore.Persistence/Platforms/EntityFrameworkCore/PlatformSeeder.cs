using GameStore.Domain.Platforms;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Persistence.EntityFrameworkCore.Seeders;

public static class PlatformSeeder
{
    public static void SeedDefaultPlaforms(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Platform>()
        .HasData(
            new Platform { Id = new Guid("e5bd3bec-2c19-4672-9f15-cd47aa277bfe"), Type = "Mobile" },
            new Platform { Id = new Guid("578e223f-82da-4c58-99c2-219e72ddba19"), Type = "Browser" },
            new Platform { Id = new Guid("027eec94-73fd-4d04-8219-2a63b8d85cca"), Type = "Desktop" },
            new Platform { Id = new Guid("22f409cd-f783-4738-9875-e520d5c62d42"), Type = "Console" });
    }
}