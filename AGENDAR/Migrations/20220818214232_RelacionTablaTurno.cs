using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Migrations
{
    public partial class RelacionTablaTurno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19b6bdf0-b06b-41c3-9bff-173baea9cf93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9d9fdca-47ca-40e7-91a9-62ebf56b3d3a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c688be32-1891-4aef-81c0-d34a44c46fc7", "df120009-c0a7-4d87-a524-29eced1a2694" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df120009-c0a7-4d87-a524-29eced1a2694");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c688be32-1891-4aef-81c0-d34a44c46fc7");

            migrationBuilder.AddColumn<int>(
                name: "ProfesionalID",
                table: "Turnos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaID",
                table: "Turnos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fad59572-9315-4956-bb39-870860d44757", "7952096d-f7a5-4cdc-adbb-e2275d2f5ced", "SuperUsuario", "SUPERUSUARIO" },
                    { "12a9cda5-7759-4731-88cf-f38eb764242d", "106487b5-ac6b-4988-927c-24d9c139220b", "AdministradorEmpresa", "ADMINISTRADOREMPRESA" },
                    { "edefc78d-53d1-48e1-bc82-99904919fd6d", "411e3ccb-1c9d-4ae5-bca3-14984200e78d", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c7fbce74-63e2-4fdf-beda-c1e793cd270e", 0, "90d06906-a781-43ba-8cb2-4d1d3f0e1b6d", "ApplicationUser", "turnosagendar@gmail.com", false, false, null, "TURNOSAGENDAR@GMAIL.COM", "TURNOSAGENDAR@GMAIL.COM", "AQAAAAEAACcQAAAAENOqP8CKTGy4a3ZF/VjDpThGtjaxv9R5BeBnYwLq6DlvR5jl3iaNmisN54qkc3mt9w==", null, false, "95c15314-e3b4-4fe3-bdd6-8512476b1217", false, "turnosagendar@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c7fbce74-63e2-4fdf-beda-c1e793cd270e", "fad59572-9315-4956-bb39-870860d44757" });

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_ClasificacionProfesionalID",
                table: "Turnos",
                column: "ClasificacionProfesionalID");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_HorarioID",
                table: "Turnos",
                column: "HorarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_LocalidadID",
                table: "Turnos",
                column: "LocalidadID");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_ClasificacionProfesional_ClasificacionProfesionalID",
                table: "Turnos",
                column: "ClasificacionProfesionalID",
                principalTable: "ClasificacionProfesional",
                principalColumn: "ClasificacionProfesionalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Horario_HorarioID",
                table: "Turnos",
                column: "HorarioID",
                principalTable: "Horario",
                principalColumn: "HorarioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Localidad_LocalidadID",
                table: "Turnos",
                column: "LocalidadID",
                principalTable: "Localidad",
                principalColumn: "LocalidadID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_ClasificacionProfesional_ClasificacionProfesionalID",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Horario_HorarioID",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Localidad_LocalidadID",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_ClasificacionProfesionalID",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_HorarioID",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_LocalidadID",
                table: "Turnos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12a9cda5-7759-4731-88cf-f38eb764242d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edefc78d-53d1-48e1-bc82-99904919fd6d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c7fbce74-63e2-4fdf-beda-c1e793cd270e", "fad59572-9315-4956-bb39-870860d44757" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fad59572-9315-4956-bb39-870860d44757");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7fbce74-63e2-4fdf-beda-c1e793cd270e");

            migrationBuilder.DropColumn(
                name: "ProfesionalID",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "ProvinciaID",
                table: "Turnos");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "df120009-c0a7-4d87-a524-29eced1a2694", "f5543d0b-755e-47a0-9a6e-99151a362c4f", "SuperUsuario", "SUPERUSUARIO" },
                    { "19b6bdf0-b06b-41c3-9bff-173baea9cf93", "fafde0d3-1561-4820-a288-f1a8f19b3003", "AdministradorEmpresa", "ADMINISTRADOREMPRESA" },
                    { "e9d9fdca-47ca-40e7-91a9-62ebf56b3d3a", "ecc0cb10-63ca-4c62-b2db-a282e39af9ff", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c688be32-1891-4aef-81c0-d34a44c46fc7", 0, "7e911a5e-1d18-4813-a199-0b071f4793d2", "ApplicationUser", "turnosagendar@gmail.com", false, false, null, "TURNOSAGENDAR@GMAIL.COM", "TURNOSAGENDAR@GMAIL.COM", "AQAAAAEAACcQAAAAEGLyoI9DT0ZI6Hb89WQyzY2Q6QN1HaYV05cgvIFdfCEGhZRENtjpVmTXtuLXb1TYXg==", null, false, "24eed3c9-9e87-44a5-912f-ccb12fa3f5d5", false, "turnosagendar@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "c688be32-1891-4aef-81c0-d34a44c46fc7", "df120009-c0a7-4d87-a524-29eced1a2694" });
        }
    }
}
