using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "151a84a5-89df-4c7c-825d-5d7972bb5458", null, "Administrator", "ADMINISTRATOR" },
                    { "2ab2fdfe-c853-4201-8578-ec690c3315bc", null, "Conservator", "CONSERVATOR" },
                    { "72ba6a96-1318-4090-8807-3e6e6e52cf10", null, "Recepcionist", "RECEPCIONIST" },
                    { "e0ff74cd-fdfc-4444-96eb-9e33d16d4222", null, "Inhabitant", "INHABITANT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "151a84a5-89df-4c7c-825d-5d7972bb5458");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ab2fdfe-c853-4201-8578-ec690c3315bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72ba6a96-1318-4090-8807-3e6e6e52cf10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0ff74cd-fdfc-4444-96eb-9e33d16d4222");
        }
    }
}
