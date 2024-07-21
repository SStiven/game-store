using GameStore.Domain.Bans;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Persistence.UserBans.EntityFrameworkCore;

public class UserBanConfiguration : IEntityTypeConfiguration<UserBan>
{
    public void Configure(EntityTypeBuilder<UserBan> builder)
    {
        builder.ToTable("user_ban");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasColumnName("id");

        builder.Property(b => b.UserName)
            .HasColumnName("user_name")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(b => b.ExpirationDate)
            .HasColumnName("expiration_date")
            .IsRequired();

        builder.HasIndex(b => b.UserName)
            .IsUnique();
    }
}
