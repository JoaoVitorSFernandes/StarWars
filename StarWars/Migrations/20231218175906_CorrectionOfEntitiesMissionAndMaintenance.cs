using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionOfEntitiesMissionAndMaintenance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Report",
                table: "MissionLog",
                type: "NVARCHAR(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "MissionLog",
                type: "NVARCHAR(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Report",
                table: "MaintenanceLog",
                type: "NVARCHAR(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "MaintenanceLog",
                type: "NVARCHAR(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "MissionLog");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "MaintenanceLog");

            migrationBuilder.AlterColumn<string>(
                name: "Report",
                table: "MissionLog",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Report",
                table: "MaintenanceLog",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(300)",
                oldMaxLength: 300);
        }
    }
}
