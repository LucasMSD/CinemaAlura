using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    public partial class CriandoRoleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "d72a30ef-455c-478e-850d-bd10d31d8d6c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "491d9128-caef-4183-9ef1-ee0de9d7556c", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edc27b11-6053-450d-ba0b-6fc7a36402f0", "AQAAAAEAACcQAAAAEPR7QHarLIm4v4tc1a4ILWx8hFEzuRYuqtdpwgskgx4jaxHpLhZH3ei77tl9kgjlNQ==", "98e96cad-10de-44ab-8a68-4ca7e1de1533" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "89aab03b-0136-4f39-8af4-32c28b55d61c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd615e46-1b5f-4761-99fe-e540adbc4b2e", "AQAAAAEAACcQAAAAEPQBYMloLj4WgdFFsyTMwJU5iEKraih3L7gyzrtdnEMxS/+N/OxxSp3rbvvFid39JA==", "f156bcab-1742-4afe-8050-b8413870871c" });
        }
    }
}
