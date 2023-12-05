using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false),
                    Slug = table.Column<string>(type: "NVARCHAR(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(120)", maxLength: 120, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Patent = table.Column<string>(type: "NVARCHAR(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserID", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Starship",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Model = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    Manufacturer = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    CostInCredits = table.Column<int>(type: "INT", maxLength: 50, nullable: false),
                    Crew = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    QuantPassengers = table.Column<int>(type: "INT", maxLength: 20, nullable: false),
                    CargoCapacity = table.Column<int>(type: "INT", maxLength: 20, nullable: false),
                    StarshipClass = table.Column<string>(type: "NVARCHAR(60)", maxLength: 60, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarshipId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Starship_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Report = table.Column<string>(type: "NVARCHAR(300)", maxLength: 300, nullable: false),
                    Report1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StarDate = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false),
                    EndDate = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false),
                    Duration = table.Column<double>(type: "FLOAT", maxLength: 60, nullable: false),
                    StarshipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceLogId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceLog_Starship",
                        column: x => x.StarshipId,
                        principalTable: "Starship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionName = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Report = table.Column<string>(type: "NVARCHAR(300)", maxLength: 300, nullable: false),
                    Report1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StarDate = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false),
                    EndDate = table.Column<DateTime>(type: "SMALLDATETIME", maxLength: 60, nullable: false),
                    Duration = table.Column<double>(type: "FLOAT", maxLength: 60, nullable: false),
                    StarshipId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionLogId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissionLog_Starship",
                        column: x => x.StarshipId,
                        principalTable: "Starship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMissionLog",
                columns: table => new
                {
                    MissionLogId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMissionLog", x => new { x.MissionLogId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserMissionLog_MissionLog_MissionLogId",
                        column: x => x.MissionLogId,
                        principalTable: "MissionLog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMissionLog_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLog_StarshipId",
                table: "MaintenanceLog",
                column: "StarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionLog_StarshipId",
                table: "MissionLog",
                column: "StarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Starship_UserId",
                table: "Starship",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMissionLog_UserId",
                table: "UserMissionLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceLog");

            migrationBuilder.DropTable(
                name: "UserMissionLog");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "MissionLog");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Starship");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
