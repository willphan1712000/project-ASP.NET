using ASP.NET_Web.Models.CustomerEntity;
using ASP.NET_Web.Models.MembershipTypeEntity;
using ASP.NET_Web.Models.OrderEntity;
using ASP.NET_Web.Models.ProductEntity;
using ASP.NET_Web.Models.ProfileEntity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Web.Models;

public partial class AspNetWebContext : IdentityDbContext<User>
{
    public AspNetWebContext()
    {
    }

    public AspNetWebContext(DbContextOptions<AspNetWebContext> options)
        : base(options)
    {
        this.ChangeTracker.LazyLoadingEnabled = false; // disable lazy loading
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;database=ASP_NET_Web;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.ApplyConfiguration(new CustomerConfig());
        modelBuilder.ApplyConfiguration(new OrderConfig());
        modelBuilder.ApplyConfiguration(new ProductConfig());
        modelBuilder.ApplyConfiguration(new ProfileConfig());
        modelBuilder.ApplyConfiguration(new MembershipTypeConfig());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<Customer> Customer {get; set;}
    public DbSet<Order> Order {get; set;}
    public DbSet<Profile> Profile {get; set;}
    public DbSet<Product> Product {get; set;}
    public DbSet<MembershipType> MembershipType {get; set;}
}
