using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Migrations
{
    public partial class camposBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
     

            migrationBuilder.AddColumn<bool>(
                name: "Domingo",
                table: "Horario",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Jueves",
                table: "Horario",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Lunes",
                table: "Horario",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Martes",
                table: "Horario",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Miercoles",
                table: "Horario",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Sabado",
                table: "Horario",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Viernes",
                table: "Horario",
                nullable: false,
                defaultValue: false);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropColumn(
                name: "Domingo",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "Jueves",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "Lunes",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "Martes",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "Miercoles",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "Sabado",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "Viernes",
                table: "Horario");

           
        }
    }
}
