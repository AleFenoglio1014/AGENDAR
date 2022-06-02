using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Data.Migrations
{
    public partial class NombreApellidoProfesional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Profesional");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Profesional",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Profesional",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Profesional");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Profesional",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
