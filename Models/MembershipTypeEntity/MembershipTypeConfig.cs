using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NET_Web.Models.MembershipTypeEntity;

public class MembershipTypeConfig : IEntityTypeConfiguration<MembershipType>
{
    public void Configure(EntityTypeBuilder<MembershipType> builder)
    {
        builder
            .ToTable("membershipType");
    
        builder
            .HasKey(m => m.Id);

        builder
            .Property(m => m.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(m => m.Name)
            .HasMaxLength(255);
    }
}