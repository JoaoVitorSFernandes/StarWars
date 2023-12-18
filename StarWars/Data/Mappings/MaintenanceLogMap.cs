using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Models;

namespace StarWars.Data.Mapping;

public class MaintenanceLogMap : IEntityTypeConfiguration<MaintenanceLog>
{
    public void Configure(EntityTypeBuilder<MaintenanceLog> builder)
    {
        builder.ToTable("MaintenanceLog");

        builder.HasKey(x => x.Id)
            .HasName("PK_MaintenanceLogId");

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Subject)
            .IsRequired()
            .HasColumnName("Subject")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120);

        builder.Property(x => x.Report)
            .IsRequired()
            .HasColumnName("Report")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(300);

        builder.Property(x => x.MaintenanceStatus)
            .IsRequired()
            .HasColumnName("MaintenanceStatus")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(10);

        builder.Property(x => x.StarDate)
            .IsRequired()
            .HasColumnName("StarDate")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60);

        builder.Property(x => x.EndDate)
            .IsRequired()
            .HasColumnName("EndDate")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60);

        builder.Property(x => x.Duration)
            .IsRequired()
            .HasColumnName("Duration")
            .HasColumnType("FLOAT")
            .HasMaxLength(60);

        builder.HasOne(x => x.Starship)
            .WithMany(x => x.MaintenanceLogs)
            .HasConstraintName("FK_MaintenanceLog_Starship")
            .OnDelete(DeleteBehavior.Cascade);
    }
}