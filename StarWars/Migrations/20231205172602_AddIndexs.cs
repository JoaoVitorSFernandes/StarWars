using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Patent",
                table: "User",
                column: "Patent",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_MissionLog_MissionName",
                table: "MissionLog",
                column: "MissionName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_Email",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Patent",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_MissionLog_Model",
                table: "Starship");

            migrationBuilder.DropIndex(
                name: "IX_MissionLog_Name",
                table: "Starship");

            migrationBuilder.DropIndex(
                name: "IX_Starship_Manafacturer",
                table: "Starship");

            migrationBuilder.DropIndex(
                name: "IX_MissionLog_MissionName",
                table: "MissionLog");
        }
    }
}
