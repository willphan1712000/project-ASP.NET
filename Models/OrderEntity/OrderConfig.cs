using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NET_Web.Models.OrderEntity;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .ToTable("orders");

        builder
            .HasKey(o => o.Id);

        builder
            .Property(o => o.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(o => o.Price)
            .IsRequired();

        builder
            .Property(o => o.Status)
            .IsRequired()
            .HasConversion<string>();
            
        builder
            .Property(o => o.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP()");
    }
}