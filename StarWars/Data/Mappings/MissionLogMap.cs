using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Models;

namespace starWars.Data.Mapping;

public class MissionLogMap : IEntityTypeConfiguration<MissionLog>
{
    public void Configure(EntityTypeBuilder<MissionLog> builder)
    {
        builder.ToTable("MissionLog");

        builder.HasKey(x => x.Id)
            .HasName("PK_MissionLogId");

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.MissionName)
            .IsRequired()
            .HasColumnName("MissionName")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);

        builder.Property(x => x.MissionStats)
            .IsRequired()
            .HasColumnName("MissionStats")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(10);

        builder.Property(x => x.Subject)
            .IsRequired()
            .HasColumnName("Subject")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(120);

        builder.Property(x => x.Subject)
            .IsRequired()
            .HasColumnName("Report")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(300);

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
            .WithMany(x => x.MissionLogs)
            .HasConstraintName("FK_MissionLog_Starship")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.MissionName, "IX_MissionLog_MissionName")
            .IsUnique();

        builder
            .HasMany(x => x.Users)
            .WithMany(x => x.MissionLogs)
            .UsingEntity<Dictionary<string, object>>(
                "UserMissionLog",
                user => user
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .HasConstraintName("FK_UserMissionLog_User_UserId")
                    .OnDelete(DeleteBehavior.ClientCascade),
                missionlog => missionlog
                    .HasOne<MissionLog>()
                    .WithMany()
                    .HasForeignKey("MissionLogId")
                    .HasConstraintName("FK_UserMissionLog_MissionLog_MissionLogId")
                    .OnDelete(DeleteBehavior.ClientCascade));
    }
}