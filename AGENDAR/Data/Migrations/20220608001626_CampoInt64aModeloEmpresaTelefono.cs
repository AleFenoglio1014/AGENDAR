using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Data.Migrations
{
    public partial class CampoInt64aModeloEmpresaTelefono : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Telefono",
                table: "Empresa",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefono",
                table: "Empresa",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
