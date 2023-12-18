using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionOfIndexs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MissionLog_Model",
                table: "Starship");

            migrationBuilder.DropIndex(
                name: "IX_MissionLog_Name",
                table: "Starship");

            migrationBuilder.DropIndex(
                name: "IX_Starship_Manafacturer",
                table: "Starship");

            migrationBuilder.CreateIndex(
                name: "IX_MissionLog_Model",
                table: "Starship",
                column: "Model");

            migrationBuilder.CreateIndex(
                name: "IX_MissionLog_Name",
                table: "Starship",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Starship_Manafacturer",
                table: "Starship",
                column: "Manufacturer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MissionLog_Model",
                table: "Starship");

            migrationBuilder.DropIndex(
                name: "IX_MissionLog_Name",
                table: "Starship");

            migrationBuilder.DropIndex(
                name: "IX_Starship_Manafacturer",
                table: "Starship");

            migrationBuilder.CreateIndex(
                name: "IX_MissionLog_Model",
                table: "Starship",
                column: "Model",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MissionLog_Name",
                table: "Starship",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Starship_Manafacturer",
                table: "Starship",
                column: "Manufacturer",
                unique: true);
        }
    }
}
