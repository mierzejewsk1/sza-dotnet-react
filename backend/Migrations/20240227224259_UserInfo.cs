using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2be4c4f9-4395-4c68-bc7a-e68e8bfdb012");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b5e1626-195d-4241-97b9-932e54b2ae84");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad3c5ff1-4559-432f-8ecd-0199c605dc8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5a6baef-0fb6-4862-995b-aea4f48e418d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d53e11a-229a-478a-a403-e84c09b36831", null, "Administrator", "ADMINISTRATOR" },
                    { "6321b158-1c61-4043-ba3e-092ab9d8c198", null, "Conservator", "CONSERVATOR" },
                    { "6fc9dcfc-ab6e-4971-a2fa-c5930a490d12", null, "Recepcionist", "RECEPCIONIST" },
                    { "ec4a6a8d-72e4-45e7-b86c-6d0108a757d6", null, "Inhabitant", "INHABITANT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MajorId",
                table: "AspNetUsers",
                column: "MajorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Majors_MajorId",
                table: "AspNetUsers",
                column: "MajorId",
                principalTable: "Majors",
                principalColumn: "MajorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Majors_MajorId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MajorId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d53e11a-229a-478a-a403-e84c09b36831");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6321b158-1c61-4043-ba3e-092ab9d8c198");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fc9dcfc-ab6e-4971-a2fa-c5930a490d12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec4a6a8d-72e4-45e7-b86c-6d0108a757d6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2be4c4f9-4395-4c68-bc7a-e68e8bfdb012", null, "Administrator", "ADMINISTRATOR" },
                    { "9b5e1626-195d-4241-97b9-932e54b2ae84", null, "Conservator", "CONSERVATOR" },
                    { "ad3c5ff1-4559-432f-8ecd-0199c605dc8b", null, "Recepcionist", "RECEPCIONIST" },
                    { "c5a6baef-0fb6-4862-995b-aea4f48e418d", null, "Inhabitant", "INHABITANT" }
                });
        }
    }
}
