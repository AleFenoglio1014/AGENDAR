using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Migrations
{
    public partial class quitarClasificaciob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresa_ClasificacionEmpresa_ClasificacionEmpresaID",
                table: "Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesional_ClasificacionProfesional_ClasificacionProfesionalID",
                table: "Profesional");

            migrationBuilder.DropTable(
                name: "ClasificacionEmpresa");

            migrationBuilder.DropTable(
                name: "ClasificacionProfesional");

            migrationBuilder.DropIndex(
                name: "IX_Profesional_ClasificacionProfesionalID",
                table: "Profesional");

            migrationBuilder.DropIndex(
                name: "IX_Empresa_ClasificacionEmpresaID",
                table: "Empresa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97600f36-3da1-4b5f-9c00-9593c9f63288");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd278de1-e923-417e-94be-0116dd8c9ebe");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "837ec2e3-9b09-4692-a658-761339df818a", "d7b35d56-1d21-4c96-be2e-0892360f4d88" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7b35d56-1d21-4c96-be2e-0892360f4d88");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "837ec2e3-9b09-4692-a658-761339df818a");

            migrationBuilder.DropColumn(
                name: "ClasificacionEmpresaID",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "ClasificacionProfesionalID",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "ClasificacionProfesionalID",
                table: "Profesional");

            migrationBuilder.DropColumn(
                name: "ClasificacionEmpresaID",
                table: "Empresa");

            migrationBuilder.AddColumn<int>(
                name: "ProfesionalID",
                table: "Horario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "188c4ba6-4ea7-4c94-882c-08207e41f1e1", "f231f596-f593-43cb-a93a-70d58423803e", "SuperUsuario", "SUPERUSUARIO" },
                    { "002650bc-f218-4403-bd8b-0361314a3e45", "44ae2e77-985e-4965-a4e3-2bc79ef61f48", "AdministradorEmpresa", "ADMINISTRADOREMPRESA" },
                    { "aaa77bda-00c0-453f-914b-5682019686b6", "91404927-95c4-43fa-9a9e-ea14a7916020", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "24c7c964-b889-4e80-b5e3-119a4e069a7b", 0, "ce03b590-90f2-4b1d-832c-6692248d0764", "ApplicationUser", "turnosagendar@gmail.com", false, false, null, "TURNOSAGENDAR@GMAIL.COM", "TURNOSAGENDAR@GMAIL.COM", "AQAAAAEAACcQAAAAECZbNvCS+dh0qhsnDL60bJbCqxxdwRSYcvUnLgo7BUHGOQjPMNClLdsowjmlCwkYYg==", null, false, "90f58ca9-be18-41e2-afb6-7c6ad5507434", false, "turnosagendar@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "24c7c964-b889-4e80-b5e3-119a4e069a7b", "188c4ba6-4ea7-4c94-882c-08207e41f1e1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "002650bc-f218-4403-bd8b-0361314a3e45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aaa77bda-00c0-453f-914b-5682019686b6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "24c7c964-b889-4e80-b5e3-119a4e069a7b", "188c4ba6-4ea7-4c94-882c-08207e41f1e1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "188c4ba6-4ea7-4c94-882c-08207e41f1e1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24c7c964-b889-4e80-b5e3-119a4e069a7b");

            migrationBuilder.DropColumn(
                name: "ProfesionalID",
                table: "Horario");

            migrationBuilder.AddColumn<int>(
                name: "ClasificacionEmpresaID",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClasificacionProfesionalID",
                table: "Turnos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClasificacionProfesionalID",
                table: "Profesional",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClasificacionEmpresaID",
                table: "Empresa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ClasificacionEmpresa",
                columns: table => new
                {
                    ClasificacionEmpresaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionEmpresa", x => x.ClasificacionEmpresaID);
                });

            migrationBuilder.CreateTable(
                name: "ClasificacionProfesional",
                columns: table => new
                {
                    ClasificacionProfesionalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionProfesional", x => x.ClasificacionProfesionalID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d7b35d56-1d21-4c96-be2e-0892360f4d88", "9378fc7b-1abd-4a47-8737-063c7f52beeb", "SuperUsuario", "SUPERUSUARIO" },
                    { "cd278de1-e923-417e-94be-0116dd8c9ebe", "e365d584-f920-4004-a8a4-76be56f8d1f7", "AdministradorEmpresa", "ADMINISTRADOREMPRESA" },
                    { "97600f36-3da1-4b5f-9c00-9593c9f63288", "641210f6-7c6f-4271-b42e-63071737e8c4", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "837ec2e3-9b09-4692-a658-761339df818a", 0, "eb19da9a-1eaa-41fc-ab8d-1f974269cea8", "ApplicationUser", "turnosagendar@gmail.com", false, false, null, "TURNOSAGENDAR@GMAIL.COM", "TURNOSAGENDAR@GMAIL.COM", "AQAAAAEAACcQAAAAEBHL6245DzDerdrNlGP1CYRvCV89Zh0Oelq2FwYB09HE0dn0jizfThSYk7zwfXnl3Q==", null, false, "47b14bd1-abc2-4013-843f-e0d3e6010520", false, "turnosagendar@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "837ec2e3-9b09-4692-a658-761339df818a", "d7b35d56-1d21-4c96-be2e-0892360f4d88" });

            migrationBuilder.CreateIndex(
                name: "IX_Profesional_ClasificacionProfesionalID",
                table: "Profesional",
                column: "ClasificacionProfesionalID");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_ClasificacionEmpresaID",
                table: "Empresa",
                column: "ClasificacionEmpresaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresa_ClasificacionEmpresa_ClasificacionEmpresaID",
                table: "Empresa",
                column: "ClasificacionEmpresaID",
                principalTable: "ClasificacionEmpresa",
                principalColumn: "ClasificacionEmpresaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesional_ClasificacionProfesional_ClasificacionProfesionalID",
                table: "Profesional",
                column: "ClasificacionProfesionalID",
                principalTable: "ClasificacionProfesional",
                principalColumn: "ClasificacionProfesionalID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
