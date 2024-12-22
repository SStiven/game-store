using GameStore.Domain.Platforms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Persistence.Platforms.EntityFrameworkCore;

public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.ToTable("platform");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id");

        builder.Property(p => p.Type)
            .HasColumnName("type")
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(p => p.Type)
            .IsUnique();
    }
}
