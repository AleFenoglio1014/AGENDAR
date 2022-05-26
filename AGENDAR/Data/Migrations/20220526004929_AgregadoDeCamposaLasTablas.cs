using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Data.Migrations
{
    public partial class AgregadoDeCamposaLasTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidad_Provincia_ProvinciasProvinciaID",
                table: "Localidad");

            migrationBuilder.DropIndex(
                name: "IX_Localidad_ProvinciasProvinciaID",
                table: "Localidad");

            migrationBuilder.DropColumn(
                name: "ProvinciasProvinciaID",
                table: "Localidad");

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Provincia",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Localidad",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaID",
                table: "Localidad",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Localidad_ProvinciaID",
                table: "Localidad",
                column: "ProvinciaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidad_Provincia_ProvinciaID",
                table: "Localidad",
                column: "ProvinciaID",
                principalTable: "Provincia",
                principalColumn: "ProvinciaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidad_Provincia_ProvinciaID",
                table: "Localidad");

            migrationBuilder.DropIndex(
                name: "IX_Localidad_ProvinciaID",
                table: "Localidad");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Provincia");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Localidad");

            migrationBuilder.DropColumn(
                name: "ProvinciaID",
                table: "Localidad");

            migrationBuilder.AddColumn<int>(
                name: "ProvinciasProvinciaID",
                table: "Localidad",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Localidad_ProvinciasProvinciaID",
                table: "Localidad",
                column: "ProvinciasProvinciaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidad_Provincia_ProvinciasProvinciaID",
                table: "Localidad",
                column: "ProvinciasProvinciaID",
                principalTable: "Provincia",
                principalColumn: "ProvinciaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
