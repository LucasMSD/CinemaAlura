using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    public partial class CriaçãodoCustomIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "d93019d2-2ad1-4ac7-87ae-2ff184b19179");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "c4f88212-8726-41cf-a4ff-d33a4d7999f8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8150ca68-0658-4fa8-bf52-cc1d0167885c", "AQAAAAEAACcQAAAAEHF82wlU588m3MBkrALS10ujAYOOO5kCYgfWzCJA7xBx4RwnHOhuIAhgL/hYVpHXVA==", "43ccf321-c6ad-4479-a830-a6820f311d65" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "491d9128-caef-4183-9ef1-ee0de9d7556c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "d72a30ef-455c-478e-850d-bd10d31d8d6c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edc27b11-6053-450d-ba0b-6fc7a36402f0", "AQAAAAEAACcQAAAAEPR7QHarLIm4v4tc1a4ILWx8hFEzuRYuqtdpwgskgx4jaxHpLhZH3ei77tl9kgjlNQ==", "98e96cad-10de-44ab-8a68-4ca7e1de1533" });
        }
    }
}
