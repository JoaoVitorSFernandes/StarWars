using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Models;

namespace StarWars.Data.Mapping;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");

        builder.HasKey(x => x.Id)
            .HasName("PK_RoleId");

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(40);

        builder.Property(x => x.Slug)
        .IsRequired()
        .HasColumnName("Slug")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(40);
    }
}
