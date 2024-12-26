using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace My_api.Migrations
{
    /// <inheritdoc />
    public partial class appUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07bb7d51-a29b-4e1d-ae3f-595122a598d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bbe0f18-90b9-4b21-b509-7a43717a4a58");

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "expiration",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00179a8d-31dc-473d-8c09-454c1d3ddca8", "e6567917-e4e9-4ab6-8614-a289b6cb04c6", "User", "user" },
                    { "ff0c80ef-7931-4aa4-ae5d-08975bf2186f", "75065338-dd7e-4df1-8d14-33c98ab2c49c", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00179a8d-31dc-473d-8c09-454c1d3ddca8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff0c80ef-7931-4aa4-ae5d-08975bf2186f");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "expiration",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07bb7d51-a29b-4e1d-ae3f-595122a598d2", "3cdd2948-c5f1-442f-88cd-b74078c8e636", "Admin", "admin" },
                    { "9bbe0f18-90b9-4b21-b509-7a43717a4a58", "ed59a623-85bc-49a4-9627-adcdd8ef2117", "User", "user" }
                });
        }
    }
}
