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
            .IsRequired()
            .HasMaxLength(MaxKeyLength)
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

        builder.Property(g => g.Price)
            .IsRequired()
            .HasColumnName("price");

        builder.Property(g => g.UnitInStock)
            .IsRequired()
            .HasColumnName("unit_in_stock");

        builder.Property(g => g.Discount)
            .IsRequired()
            .HasColumnName("discount");

        builder.Property(g => g.Discontinued)
            .IsRequired()
            .HasColumnName("discontinued")
            .HasDefaultValue(false);

        builder.Property(g => g.QuantityPerUnit)
            .IsRequired()
            .HasColumnName("quantity_per_unit");

        builder.Property(g => g.ReorderLevel)
            .IsRequired()
            .HasColumnName("reorder_level");

        builder.Property(g => g.PublisherId)
            .HasColumnName("publisher_id");

        builder.HasOne(g => g.Publisher)
            .WithMany(p => p.Games)
            .HasForeignKey(g => g.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);

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
