using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Migrations
{
    public partial class eliminadoTurno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<int>(
                name: "Eliminado",
                table: "Turnos",
                nullable: false,
                defaultValue: 0);

           }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Turnos");

           
        }
    }
}
