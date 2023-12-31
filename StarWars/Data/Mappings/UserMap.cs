using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Models;

namespace StarWars.Data.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(x => x.Id)
            .HasName("PK_UserID");

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(120);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnName("Password")
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);

        builder.Property(x => x.Patent)
            .IsRequired()
            .HasColumnName("Patent")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(25);

        builder.HasIndex(x => x.Email, "IX_User_Email")
            .IsUnique();

        builder.HasIndex(x => x.Patent, "IX_User_Patent")
            .IsUnique();

        builder
            .HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                role => role
                    .HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .HasConstraintName("FK_UserRole_RoleId")
                    .OnDelete(DeleteBehavior.Cascade),
                user => user
                    .HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .HasConstraintName("FK_UserRole_UserId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}