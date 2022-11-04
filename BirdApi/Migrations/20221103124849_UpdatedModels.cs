using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdApi.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sighting_BirdId",
                table: "Sighting",
                column: "BirdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sighting_Birds_BirdId",
                table: "Sighting",
                column: "BirdId",
                principalTable: "Birds",
                principalColumn: "BirdId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sighting_Birds_BirdId",
                table: "Sighting");

            migrationBuilder.DropIndex(
                name: "IX_Sighting_BirdId",
                table: "Sighting");
        }
    }
}
