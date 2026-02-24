using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NET_Web.Models.OrderItemEntity;

public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder
            .ToTable("orderItems");

        builder
            .HasKey(o => o.Id);

        builder
            .Property(o => o.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasOne(o => o.Product)
            .WithOne(p => p.Item)
            .HasForeignKey<OrderItem>(o => o.ProductId);

        builder
            .HasOne(o => o.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(o => o.OrderId);
    }
}