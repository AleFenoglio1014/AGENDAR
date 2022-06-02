using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Data.Migrations
{
    public partial class StringTipoYLocalidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_ClasificacionEmpresa_ClasificacionEmpresasClasificacionEmpresaID",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Localidad_LocalidadesLocalidadID",
                table: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_ClasificacionEmpresasClasificacionEmpresaID",
                table: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_LocalidadesLocalidadID",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "ClasificacionEmpresasClasificacionEmpresaID",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "LocalidadesLocalidadID",
                table: "Empresa");

            migrationBuilder.AddColumn<int>(
                name: "ClasificacionEmpresaID",
                table: "Empresa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocalidadID",
                table: "Empresa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_ClasificacionEmpresaID",
                table: "Empresa",
                column: "ClasificacionEmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_LocalidadID",
                table: "Empresa",
                column: "LocalidadID");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_ClasificacionEmpresa_ClasificacionEmpresaID",
                table: "Empresa",
                column: "ClasificacionEmpresaID",
                principalTable: "ClasificacionEmpresa",
                principalColumn: "ClasificacionEmpresaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Localidad_LocalidadID",
                table: "Empresa",
                column: "LocalidadID",
                principalTable: "Localidad",
                principalColumn: "LocalidadID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_ClasificacionEmpresa_ClasificacionEmpresaID",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_Localidad_LocalidadID",
                table: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_ClasificacionEmpresaID",
                table: "Empresa");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_LocalidadID",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "ClasificacionEmpresaID",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "LocalidadID",
                table: "Empresa");

            migrationBuilder.AddColumn<int>(
                name: "ClasificacionEmpresasClasificacionEmpresaID",
                table: "Empresa",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalidadesLocalidadID",
                table: "Empresa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_ClasificacionEmpresasClasificacionEmpresaID",
                table: "Empresa",
                column: "ClasificacionEmpresasClasificacionEmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_LocalidadesLocalidadID",
                table: "Empresa",
                column: "LocalidadesLocalidadID");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_ClasificacionEmpresa_ClasificacionEmpresasClasificacionEmpresaID",
                table: "Empresa",
                column: "ClasificacionEmpresasClasificacionEmpresaID",
                principalTable: "ClasificacionEmpresa",
                principalColumn: "ClasificacionEmpresaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_Localidad_LocalidadesLocalidadID",
                table: "Empresa",
                column: "LocalidadesLocalidadID",
                principalTable: "Localidad",
                principalColumn: "LocalidadID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
