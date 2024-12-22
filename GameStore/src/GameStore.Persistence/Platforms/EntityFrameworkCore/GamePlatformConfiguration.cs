using GameStore.Domain.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Persistence.Platforms.EntityFrameworkCore;

public class GamePlatformConfiguration : IEntityTypeConfiguration<GamePlatform>
{
    public void Configure(EntityTypeBuilder<GamePlatform> builder)
    {
        builder.ToTable("game_platform");

        builder.HasKey(gp => new { gp.GameId, gp.PlatformId });

        builder.Property(gg => gg.GameId)
            .HasColumnName("game_id");

        builder.Property(gg => gg.PlatformId)
            .HasColumnName("platform_id");

        builder.HasOne(gp => gp.Game)
            .WithMany(g => g.GamePlatforms)
            .HasForeignKey(gp => gp.GameId);

        builder.HasOne(gp => gp.Platform)
            .WithMany(p => p.GamePlatforms)
            .HasForeignKey(gp => gp.PlatformId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
