using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdApi.Migrations
{
    public partial class UserIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d75ccf86-654b-4766-ac1b-6e47e77b3053");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7e6f4d3-c14d-4560-b2b9-380c2acdfbbb");

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Sighting",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27896df1-ad84-4dca-9066-d91eafc06ff8", "803caae2-beeb-4c67-9db2-31b191fcaf78", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c88e52f3-2afa-4b03-9321-ba25dd247d3a", "f5011465-fa3d-40b1-a4d3-49a28a0d41a8", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27896df1-ad84-4dca-9066-d91eafc06ff8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c88e52f3-2afa-4b03-9321-ba25dd247d3a");

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Sighting");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d75ccf86-654b-4766-ac1b-6e47e77b3053", "2360ed7b-7ca4-408f-9aac-fb5cc35fe302", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7e6f4d3-c14d-4560-b2b9-380c2acdfbbb", "913367e3-1649-4c3f-9b94-a29dda4439a0", "Member", "MEMBER" });
        }
    }
}
