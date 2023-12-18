﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarWars.Data;

#nullable disable

namespace StarWars.Migrations
{
    [DbContext(typeof(StarWarsDataContext))]
    partial class StarWarsDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StarWars.Models.MaintenanceLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Duration")
                        .HasMaxLength(60)
                        .HasColumnType("FLOAT")
                        .HasColumnName("Duration");

                    b.Property<DateTime>("EndDate")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("EndDate");

                    b.Property<string>("MaintenanceStatus")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("MaintenanceStatus");

                    b.Property<string>("Report")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Report");

                    b.Property<DateTime>("StarDate")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("StarDate");

                    b.Property<int>("StarshipId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Subject");

                    b.HasKey("Id")
                        .HasName("PK_MaintenanceLogId");

                    b.HasIndex("StarshipId");

                    b.ToTable("MaintenanceLog", (string)null);
                });

            modelBuilder.Entity("StarWars.Models.MissionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Duration")
                        .HasMaxLength(60)
                        .HasColumnType("FLOAT")
                        .HasColumnName("Duration");

                    b.Property<DateTime>("EndDate")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("EndDate");

                    b.Property<string>("MissionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("MissionName");

                    b.Property<string>("MissionStats")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("MissionStats");

                    b.Property<string>("Report")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Report");

                    b.Property<DateTime>("StarDate")
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("StarDate");

                    b.Property<int>("StarshipId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Subject");

                    b.HasKey("Id")
                        .HasName("PK_MissionLogId");

                    b.HasIndex("StarshipId");

                    b.HasIndex(new[] { "MissionName" }, "IX_MissionLog_MissionName")
                        .IsUnique();

                    b.ToTable("MissionLog", (string)null);
                });

            modelBuilder.Entity("StarWars.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Slug");

                    b.HasKey("Id")
                        .HasName("PK_RoleId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("StarWars.Models.Starship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CargoCapacity")
                        .HasMaxLength(20)
                        .HasColumnType("INT")
                        .HasColumnName("CargoCapacity");

                    b.Property<int>("CostInCredits")
                        .HasMaxLength(50)
                        .HasColumnType("INT")
                        .HasColumnName("CostInCredits");

                    b.Property<string>("Crew")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Crew");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Manufacturer");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Model");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<int>("Passengers")
                        .HasMaxLength(20)
                        .HasColumnType("INT")
                        .HasColumnName("QuantPassengers");

                    b.Property<string>("StarshipClass")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("StarshipClass");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_StarshipId");

                    b.HasIndex("UserId");

                    b.HasIndex(new[] { "Manufacturer" }, "IX_Starship_Manafacturer");

                    b.HasIndex(new[] { "Model" }, "IX_Starship_Model");

                    b.HasIndex(new[] { "Name" }, "IX_Starship_Name");

                    b.ToTable("Starship", (string)null);
                });

            modelBuilder.Entity("StarWars.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Password");

                    b.Property<string>("Patent")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Patent");

                    b.HasKey("Id")
                        .HasName("PK_UserID");

                    b.HasIndex(new[] { "Email" }, "IX_User_Email")
                        .IsUnique();

                    b.HasIndex(new[] { "Patent" }, "IX_User_Patent")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("UserMissionLog", b =>
                {
                    b.Property<int>("MissionLogId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MissionLogId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMissionLog");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("StarWars.Models.MaintenanceLog", b =>
                {
                    b.HasOne("StarWars.Models.Starship", "Starship")
                        .WithMany("MaintenanceLogs")
                        .HasForeignKey("StarshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_MaintenanceLog_Starship");

                    b.Navigation("Starship");
                });

            modelBuilder.Entity("StarWars.Models.MissionLog", b =>
                {
                    b.HasOne("StarWars.Models.Starship", "Starship")
                        .WithMany("MissionLogs")
                        .HasForeignKey("StarshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_MissionLog_Starship");

                    b.Navigation("Starship");
                });

            modelBuilder.Entity("StarWars.Models.Starship", b =>
                {
                    b.HasOne("StarWars.Models.User", "User")
                        .WithMany("Starships")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Starship_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserMissionLog", b =>
                {
                    b.HasOne("StarWars.Models.MissionLog", null)
                        .WithMany()
                        .HasForeignKey("MissionLogId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserMissionLog_MissionLog_MissionLogId");

                    b.HasOne("StarWars.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserMissionLog_User_UserId");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("StarWars.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_RoleId");

                    b.HasOne("StarWars.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_UserId");
                });

            modelBuilder.Entity("StarWars.Models.Starship", b =>
                {
                    b.Navigation("MaintenanceLogs");

                    b.Navigation("MissionLogs");
                });

            modelBuilder.Entity("StarWars.Models.User", b =>
                {
                    b.Navigation("Starships");
                });
#pragma warning restore 612, 618
        }
    }
}
