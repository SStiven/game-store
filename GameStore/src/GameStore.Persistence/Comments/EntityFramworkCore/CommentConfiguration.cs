using GameStore.Domain.Comments;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Persistence.Comments.EntityFramworkCore;
internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("comment");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id");

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(c => c.Body)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("body");

        builder.Property(c => c.ParentId)
            .HasColumnName("parent_id");

        builder.Property(c => c.GameId)
            .HasColumnName("game_id")
            .IsRequired();

        builder.HasMany(c => c.Replies)
                .WithOne()
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.ClientCascade);
    }
}
