using GameStore.Domain.Orders;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Persistence.Orders.EntityFrameworkCore;

public class OrderGameConfiguration : IEntityTypeConfiguration<OrderGame>
{
    public void Configure(EntityTypeBuilder<OrderGame> builder)
    {
        builder.ToTable("order_game");

        builder.HasKey(og => new { og.OrderId, og.ProductId });

        builder.Property(og => og.OrderId)
            .HasColumnName("order_id")
            .IsRequired();

        builder.Property(og => og.ProductId)
            .HasColumnName("product_id")
            .IsRequired();

        builder.Property(og => og.Price)
            .HasColumnName("price")
            .IsRequired();

        builder.Property(og => og.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        builder.Property(og => og.Discount)
            .HasColumnName("discount");

        builder.HasOne(og => og.Order)
            .WithMany(o => o.OrderGames)
            .HasForeignKey(og => og.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(og => og.Game)
            .WithMany()
            .HasForeignKey(og => og.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
