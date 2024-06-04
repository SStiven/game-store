using GameStore.Domain.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Persistence.Games.EntityFrameworkCore;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    private const int MaxNameLength = 100;
    private const int MaxKeyLength = MaxNameLength + 5;

    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("game");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .HasColumnName("id");

        builder.Property(g => g.Key)
            .IsRequired().HasMaxLength(MaxKeyLength)
            .HasColumnName("key");

        builder.HasIndex(g => g.Key)
            .IsUnique();

        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(MaxNameLength)
            .HasColumnName("name");

        builder.Property(g => g.Description)
            .HasMaxLength(500)
            .HasColumnName("description");

        builder.HasMany(g => g.GameGenres)
            .WithOne(gg => gg.Game)
            .HasForeignKey(gg => gg.GameId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(g => g.GamePlatforms)
            .WithOne(gp => gp.Game)
            .HasForeignKey(gp => gp.GameId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
