using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76c1f1bf-d923-4ea2-8a41-719c460e14c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a503f99e-5590-4567-bb04-168abef9f81f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1ec5194-991e-4f15-86fb-ae32227fd75d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b5d1e9f6-6c10-4c8a-9e1d-111111111111", null, "User", "USER" },
                    { "b5d1e9f6-6c10-4c8a-9e1d-222222222222", null, "Editor", "EDITOR" },
                    { "b5d1e9f6-6c10-4c8a-9e1d-333333333333", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5d1e9f6-6c10-4c8a-9e1d-111111111111");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5d1e9f6-6c10-4c8a-9e1d-222222222222");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5d1e9f6-6c10-4c8a-9e1d-333333333333");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76c1f1bf-d923-4ea2-8a41-719c460e14c3", null, "User", "USER" },
                    { "a503f99e-5590-4567-bb04-168abef9f81f", null, "Editor", "EDITOR" },
                    { "c1ec5194-991e-4f15-86fb-ae32227fd75d", null, "Admin", "ADMIN" }
                });
        }
    }
}
