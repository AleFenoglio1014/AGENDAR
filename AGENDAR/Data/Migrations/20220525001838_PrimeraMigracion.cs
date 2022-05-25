using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Data.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClasificacionEmpresa",
                columns: table => new
                {
                    ClasificacionEmpresaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionEmpresa", x => x.ClasificacionEmpresaID);
                });

            migrationBuilder.CreateTable(
                name: "ClasificacionProfesional",
                columns: table => new
                {
                    ClasificacionProfesionalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionProfesional", x => x.ClasificacionProfesionalID);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    ProvinciaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.ProvinciaID);
                });

            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    LocalidadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    CodPostal = table.Column<string>(nullable: true),
                    ProvinciasProvinciaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.LocalidadID);
                    table.ForeignKey(
                        name: "FK_Localidad_Provincia_ProvinciasProvinciaID",
                        column: x => x.ProvinciasProvinciaID,
                        principalTable: "Provincia",
                        principalColumn: "ProvinciaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    EmpresaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(nullable: true),
                    CUIT = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    LocalidadesLocalidadID = table.Column<int>(nullable: true),
                    ClasificacionEmpresasClasificacionEmpresaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.EmpresaID);
                    table.ForeignKey(
                        name: "FK_Empresa_ClasificacionEmpresa_ClasificacionEmpresasClasificacionEmpresaID",
                        column: x => x.ClasificacionEmpresasClasificacionEmpresaID,
                        principalTable: "ClasificacionEmpresa",
                        principalColumn: "ClasificacionEmpresaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empresa_Localidad_LocalidadesLocalidadID",
                        column: x => x.LocalidadesLocalidadID,
                        principalTable: "Localidad",
                        principalColumn: "LocalidadID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profesional",
                columns: table => new
                {
                    ProfesionalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true),
                    ClasificacionProfesionalesClasificacionProfesionalID = table.Column<int>(nullable: true),
                    EmpresasEmpresaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesional", x => x.ProfesionalID);
                    table.ForeignKey(
                        name: "FK_Profesional_ClasificacionProfesional_ClasificacionProfesionalesClasificacionProfesionalID",
                        column: x => x.ClasificacionProfesionalesClasificacionProfesionalID,
                        principalTable: "ClasificacionProfesional",
                        principalColumn: "ClasificacionProfesionalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profesional_Empresa_EmpresasEmpresaID",
                        column: x => x.EmpresasEmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "EmpresaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_ClasificacionEmpresasClasificacionEmpresaID",
                table: "Empresa",
                column: "ClasificacionEmpresasClasificacionEmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_LocalidadesLocalidadID",
                table: "Empresa",
                column: "LocalidadesLocalidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Localidad_ProvinciasProvinciaID",
                table: "Localidad",
                column: "ProvinciasProvinciaID");

            migrationBuilder.CreateIndex(
                name: "IX_Profesional_ClasificacionProfesionalesClasificacionProfesionalID",
                table: "Profesional",
                column: "ClasificacionProfesionalesClasificacionProfesionalID");

            migrationBuilder.CreateIndex(
                name: "IX_Profesional_EmpresasEmpresaID",
                table: "Profesional",
                column: "EmpresasEmpresaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profesional");

            migrationBuilder.DropTable(
                name: "ClasificacionProfesional");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "ClasificacionEmpresa");

            migrationBuilder.DropTable(
                name: "Localidad");

            migrationBuilder.DropTable(
                name: "Provincia");
        }
    }
}
