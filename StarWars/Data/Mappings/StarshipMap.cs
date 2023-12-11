using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Models;

namespace StarWars.Data.Mapping;

public class StarshipMap : IEntityTypeConfiguration<Starship>
{
    public void Configure(EntityTypeBuilder<Starship> builder)
    {
        builder.ToTable("Starship");

        builder.HasKey(x => x.Id)
            .HasName("PK_StarshipId");

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);
        
        builder.Property(x => x.Model)
            .IsRequired()
            .HasColumnName("Model")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.Manufacturer)
            .IsRequired()
            .HasColumnName("Manufacturer")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.CostInCredits)
            .IsRequired()
            .HasColumnName("CostInCredits")
            .HasColumnType("INT")
            .HasMaxLength(50);

        builder.Property(x => x.Crew)
            .IsRequired()
            .HasColumnName("Crew")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.Property(x => x.Passengers)
            .IsRequired()
            .HasColumnName("QuantPassengers")
            .HasColumnType("INT")
            .HasMaxLength(20);

        builder.Property(x => x.CargoCapacity)
            .IsRequired()
            .HasColumnName("CargoCapacity")
            .HasColumnType("INT")
            .HasMaxLength(20);

        builder.Property(x => x.StarshipClass)
            .IsRequired()
            .HasColumnName("StarshipClass")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(60);

        builder.HasIndex(x => x.Name, "IX_MissionLog_Name")
            .IsUnique();

        builder.HasIndex(x => x.Model, "IX_MissionLog_Model")
            .IsUnique();

        builder.HasIndex(x => x.Manufacturer, "IX_Starship_Manafacturer")
            .IsUnique();

        builder.HasOne(x => x.User)
            .WithMany(x => x.Starships)
            .HasConstraintName("FK_Starship_User")
            .OnDelete(DeleteBehavior.Cascade);
    }
}