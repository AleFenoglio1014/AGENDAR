using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Migrations
{
    public partial class Relaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_ClasificacionProfesional_ClasificacionProfesionalID",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Localidad_LocalidadID",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_ClasificacionProfesionalID",
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
                name: "IX_Turnos_ProfesionalID",
                table: "Turnos",
                column: "ProfesionalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Profesional_ProfesionalID",
                table: "Turnos",
                column: "ProfesionalID",
                principalTable: "Profesional",
                principalColumn: "ProfesionalID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Profesional_ProfesionalID",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_ProfesionalID",
                table: "Turnos");

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
                name: "FK_Turnos_Localidad_LocalidadID",
                table: "Turnos",
                column: "LocalidadID",
                principalTable: "Localidad",
                principalColumn: "LocalidadID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
