using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Data.Migrations
{
    public partial class TablaProfesional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesional_Empresa_EmpresasEmpresaID",
                table: "Profesional");

            migrationBuilder.DropIndex(
                name: "IX_Profesional_EmpresasEmpresaID",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "EmpresasEmpresaID",
                table: "Profesional");

            migrationBuilder.AddColumn<int>(
                name: "ClasificacionEmpresaID",
                table: "Profesional",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Profesional",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaID",
                table: "Profesional",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Profesional_EmpresaID",
                table: "Profesional",
                column: "EmpresaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesional_Empresa_EmpresaID",
                table: "Profesional",
                column: "EmpresaID",
                principalTable: "Empresa",
                principalColumn: "EmpresaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesional_Empresa_EmpresaID",
                table: "Profesional");

            migrationBuilder.DropIndex(
                name: "IX_Profesional_EmpresaID",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "ClasificacionEmpresaID",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "EmpresaID",
                table: "Profesional");

            migrationBuilder.AddColumn<int>(
                name: "EmpresasEmpresaID",
                table: "Profesional",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesional_EmpresasEmpresaID",
                table: "Profesional",
                column: "EmpresasEmpresaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesional_Empresa_EmpresasEmpresaID",
                table: "Profesional",
                column: "EmpresasEmpresaID",
                principalTable: "Empresa",
                principalColumn: "EmpresaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
