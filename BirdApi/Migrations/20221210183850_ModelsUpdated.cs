using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BirdApi.Migrations
{
    public partial class ModelsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27896df1-ad84-4dca-9066-d91eafc06ff8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c88e52f3-2afa-4b03-9321-ba25dd247d3a");

            migrationBuilder.AddColumn<string>(
                name: "Conservation_status",
                table: "Birds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ab070cf-a1b7-4777-907b-53ceb5ffb28c", "92ca3064-5c07-4ce5-82ec-3f58e3e91948", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7d42f31-25d8-4f80-8ef3-89603c98b8d1", "de22450e-ddf2-4abb-8896-69dc49466704", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ab070cf-a1b7-4777-907b-53ceb5ffb28c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7d42f31-25d8-4f80-8ef3-89603c98b8d1");

            migrationBuilder.DropColumn(
                name: "Conservation_status",
                table: "Birds");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27896df1-ad84-4dca-9066-d91eafc06ff8", "803caae2-beeb-4c67-9db2-31b191fcaf78", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c88e52f3-2afa-4b03-9321-ba25dd247d3a", "f5011465-fa3d-40b1-a4d3-49a28a0d41a8", "Member", "MEMBER" });
        }
    }
}
