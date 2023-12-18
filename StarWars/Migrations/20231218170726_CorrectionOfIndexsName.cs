using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionOfIndexsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_MissionLog_Name",
                table: "Starship",
                newName: "IX_Starship_Name");

            migrationBuilder.RenameIndex(
                name: "IX_MissionLog_Model",
                table: "Starship",
                newName: "IX_Starship_Model");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Starship_Name",
                table: "Starship",
                newName: "IX_MissionLog_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Starship_Model",
                table: "Starship",
                newName: "IX_MissionLog_Model");
        }
    }
}
