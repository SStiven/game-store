using GameStore.Domain.Genres;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Persistence.Genres.EntityFrameworkCore;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("genre");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .HasColumnName("id");

        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(g => g.ParentGenreId)
            .HasColumnName("parent_genre_id");

        builder.Property(g => g.Picture)
            .HasColumnName("picture")
            .HasColumnType("varbinary(max)");

        builder.Property(g => g.Description)
            .HasColumnName("description");

        builder.HasIndex(g => g.Name)
            .IsUnique();

        builder.HasOne(g => g.ParentGenre)
            .WithMany(g => g.SubGenres)
            .HasForeignKey(g => g.ParentGenreId);
    }
}
