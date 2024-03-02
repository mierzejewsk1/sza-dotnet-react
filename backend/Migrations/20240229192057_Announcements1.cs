using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Announcements1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Majors_Departments_DepartmentId",
                table: "Majors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26c55e95-324e-4c86-a41b-34763dd4b0ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56c11309-152a-40b2-a56c-deb52a373693");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3ade3df-2e14-4cbc-82cd-9e4fd56bd860");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e01c3b6c-647b-4be5-9f83-c20fed68d058");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Majors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripton",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Announcements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "305edcc5-41cd-4634-910e-6efac1fdfb18", null, "Conservator", "CONSERVATOR" },
                    { "46e70be8-f0b4-478b-beb2-978b7497e197", null, "Recepcionist", "RECEPCIONIST" },
                    { "6475e60b-2a53-45f0-94ba-bd7ebeb086e5", null, "Inhabitant", "INHABITANT" },
                    { "a301b006-c8a4-45e4-a789-e13ffa3dba65", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Majors_Departments_DepartmentId",
                table: "Majors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Majors_Departments_DepartmentId",
                table: "Majors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "305edcc5-41cd-4634-910e-6efac1fdfb18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46e70be8-f0b4-478b-beb2-978b7497e197");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6475e60b-2a53-45f0-94ba-bd7ebeb086e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a301b006-c8a4-45e4-a789-e13ffa3dba65");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Announcements");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Majors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripton",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26c55e95-324e-4c86-a41b-34763dd4b0ee", null, "Inhabitant", "INHABITANT" },
                    { "56c11309-152a-40b2-a56c-deb52a373693", null, "Administrator", "ADMINISTRATOR" },
                    { "a3ade3df-2e14-4cbc-82cd-9e4fd56bd860", null, "Recepcionist", "RECEPCIONIST" },
                    { "e01c3b6c-647b-4be5-9f83-c20fed68d058", null, "Conservator", "CONSERVATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Majors_Departments_DepartmentId",
                table: "Majors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }
    }
}
