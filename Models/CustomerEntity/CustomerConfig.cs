using ASP.NET_Web.Models.ProductEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NET_Web.Models.CustomerEntity;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");

        builder
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(c => c.Name)
            .IsRequired();

        builder
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.Customer_id)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(c => c.Products)
            .WithMany(p => p.Customers)
            .UsingEntity<Dictionary<string, object>>(
                "WishList",
                l => l.HasOne<Product>().WithMany().HasForeignKey("product_id"),
                r => r.HasOne<Customer>().WithMany().HasForeignKey("customer_id"),
                j =>
                {
                    j.ToTable("wishlist");
                    j.HasKey("customer_id", "product_id");
                }
            );
    }
}