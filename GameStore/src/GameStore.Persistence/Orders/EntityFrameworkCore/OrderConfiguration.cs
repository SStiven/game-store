using GameStore.Domain.Orders;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameStore.Persistence.Orders.EntityFrameworkCore;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("order");

        builder.HasKey(o => o.Id);

        builder.Property(g => g.Id)
            .HasColumnName("id");

        builder.Property(o => o.Date)
            .HasColumnName("date");

        builder.Property(o => o.Status)
            .IsRequired()
            .HasColumnName("status");

        builder.Property(o => o.CustomerId)
            .IsRequired()
            .HasColumnName("customer_id");

        builder.HasMany(o => o.OrderGames)
            .WithOne(og => og.Order)
            .HasForeignKey(og => og.OrderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
