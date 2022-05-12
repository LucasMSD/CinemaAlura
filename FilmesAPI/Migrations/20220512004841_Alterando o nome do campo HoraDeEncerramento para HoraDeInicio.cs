using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesAPI.Migrations
{
    public partial class AlterandoonomedocampoHoraDeEncerramentoparaHoraDeInicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HorarioDeEncerramento",
                table: "Sessoes",
                newName: "HorarioDeInicio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HorarioDeInicio",
                table: "Sessoes",
                newName: "HorarioDeEncerramento");
        }
    }
}
