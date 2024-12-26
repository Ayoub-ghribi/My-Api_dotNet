using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace My_api.Migrations
{
    /// <inheritdoc />
    public partial class imgAnimation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00179a8d-31dc-473d-8c09-454c1d3ddca8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff0c80ef-7931-4aa4-ae5d-08975bf2186f");

            migrationBuilder.CreateTable(
                name: "imgAnimations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imqge = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imgAnimations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b1e768e-f9d8-4409-b69e-c6a3f99f2142", "6bd8d3d8-ee65-44a7-a5d8-4982b5ee3134", "Admin", "admin" },
                    { "622a4d9e-0f0b-4ecd-a9ce-25f21dc4220a", "952f03c0-bae4-4745-ae97-8e22d74acd71", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imgAnimations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b1e768e-f9d8-4409-b69e-c6a3f99f2142");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "622a4d9e-0f0b-4ecd-a9ce-25f21dc4220a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00179a8d-31dc-473d-8c09-454c1d3ddca8", "e6567917-e4e9-4ab6-8614-a289b6cb04c6", "User", "user" },
                    { "ff0c80ef-7931-4aa4-ae5d-08975bf2186f", "75065338-dd7e-4df1-8d14-33c98ab2c49c", "Admin", "admin" }
                });
        }
    }
}
