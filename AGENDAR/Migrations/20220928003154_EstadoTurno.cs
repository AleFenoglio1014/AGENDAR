using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Migrations
{
    public partial class EstadoTurno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Turnos");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Turnos",
                nullable: false,
                defaultValue: 0);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Turnos");

            migrationBuilder.AddColumn<int>(
                name: "Eliminado",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            
        }
    }
}
