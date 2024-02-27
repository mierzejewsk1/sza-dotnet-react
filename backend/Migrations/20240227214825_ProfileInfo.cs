using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class ProfileInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "MajorId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    MajorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.MajorId);
                    table.ForeignKey(
                        name: "FK_Majors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                });

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

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, "WIMiI" },
                    { 2, "WZ" }
                });

            migrationBuilder.InsertData(
                table: "Majors",
                columns: new[] { "MajorId", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Informatyka" },
                    { 2, 1, "MSiTI" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Majors_DepartmentId",
                table: "Majors",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropTable(
                name: "Departments");

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

            migrationBuilder.DropColumn(
                name: "MajorId",
                table: "AspNetUsers");

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
    }
}
