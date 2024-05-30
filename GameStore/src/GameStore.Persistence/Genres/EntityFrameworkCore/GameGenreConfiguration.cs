using GameStore.Domain.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Persistence.Genres.EntityFrameworkCore;

public class GameGenreConfiguration : IEntityTypeConfiguration<GameGenre>
{
    public void Configure(EntityTypeBuilder<GameGenre> builder)
    {
        builder.ToTable("game_genre");

        builder.HasKey(gg => new { gg.GameId, gg.GenreId });

        builder.Property(gg => gg.GameId)
            .HasColumnName("game_id");

        builder.Property(gg => gg.GenreId)
            .HasColumnName("genre_id");

        builder.HasOne(gg => gg.Game)
            .WithMany(g => g.GameGenres)
            .HasForeignKey(gg => gg.GameId);

        builder.HasOne(gg => gg.Genre)
            .WithMany(g => g.GameGenres)
            .HasForeignKey(gg => gg.GenreId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
