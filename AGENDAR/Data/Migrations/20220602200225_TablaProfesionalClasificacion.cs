using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Data.Migrations
{
    public partial class TablaProfesionalClasificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesional_ClasificacionProfesional_ClasificacionProfesionalesClasificacionProfesionalID",
                table: "Profesional");

            migrationBuilder.DropIndex(
                name: "IX_Profesional_ClasificacionProfesionalesClasificacionProfesionalID",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "ClasificacionEmpresaID",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "ClasificacionProfesionalesClasificacionProfesionalID",
                table: "Profesional");

            migrationBuilder.AddColumn<int>(
                name: "ClasificacionProfesionalID",
                table: "Profesional",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Profesional_ClasificacionProfesionalID",
                table: "Profesional",
                column: "ClasificacionProfesionalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesional_ClasificacionProfesional_ClasificacionProfesionalID",
                table: "Profesional",
                column: "ClasificacionProfesionalID",
                principalTable: "ClasificacionProfesional",
                principalColumn: "ClasificacionProfesionalID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profesional_ClasificacionProfesional_ClasificacionProfesionalID",
                table: "Profesional");

            migrationBuilder.DropIndex(
                name: "IX_Profesional_ClasificacionProfesionalID",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "ClasificacionProfesionalID",
                table: "Profesional");

            migrationBuilder.AddColumn<int>(
                name: "ClasificacionEmpresaID",
                table: "Profesional",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClasificacionProfesionalesClasificacionProfesionalID",
                table: "Profesional",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesional_ClasificacionProfesionalesClasificacionProfesionalID",
                table: "Profesional",
                column: "ClasificacionProfesionalesClasificacionProfesionalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesional_ClasificacionProfesional_ClasificacionProfesionalesClasificacionProfesionalID",
                table: "Profesional",
                column: "ClasificacionProfesionalesClasificacionProfesionalID",
                principalTable: "ClasificacionProfesional",
                principalColumn: "ClasificacionProfesionalID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
