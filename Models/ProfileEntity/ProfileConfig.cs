using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NET_Web.Models.ProfileEntity;

public class ProfileConfig : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder
            .ToTable("profile");

        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
}