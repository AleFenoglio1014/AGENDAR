using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Migrations
{
    public partial class tablaturno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60f9aeb5-612f-4907-b96a-f9dd8ba4de5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3d7a1ca-912c-4254-b7f2-dad0dd56fda9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "a959c4ec-7dc2-4360-a949-b768669e58ff", "0f85fb0e-2506-4ebd-a55f-c514694fb554" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f85fb0e-2506-4ebd-a55f-c514694fb554");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a959c4ec-7dc2-4360-a949-b768669e58ff");

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                table: "Horario",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    TurnoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefono = table.Column<long>(nullable: false),
                    LocalidadID = table.Column<int>(nullable: false),
                    ClasificacionEmpresaID = table.Column<int>(nullable: false),
                    EmpresaID = table.Column<int>(nullable: false),
                    ClasificacionProfesionalID = table.Column<int>(nullable: false),
                    HorarioID = table.Column<int>(nullable: false),
                    FechaTurno = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.TurnoID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnos");

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

            migrationBuilder.DropColumn(
                name: "Eliminado",
                table: "Horario");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f85fb0e-2506-4ebd-a55f-c514694fb554", "c9b8f0a0-ff9c-4d1e-84f6-71ad1dd61920", "SuperUsuario", "SUPERUSUARIO" },
                    { "60f9aeb5-612f-4907-b96a-f9dd8ba4de5c", "33b0c0ce-10d8-4399-b244-8d6ee8381784", "AdministradorEmpresa", "ADMINISTRADOREMPRESA" },
                    { "d3d7a1ca-912c-4254-b7f2-dad0dd56fda9", "5a8ae533-b202-4f51-9331-2bb1f80bbebf", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a959c4ec-7dc2-4360-a949-b768669e58ff", 0, "74ec7768-8051-4700-b946-75c0101c2780", "ApplicationUser", "turnosagendar@gmail.com", false, false, null, "TURNOSAGENDAR@GMAIL.COM", "TURNOSAGENDAR@GMAIL.COM", "AQAAAAEAACcQAAAAEB37aeCv7nwR3bXwLMgLX8QjSjI1CjrmQwUihYxesBttDxzQ9hvhDuy2U3LknrggwQ==", null, false, "ddbc28d2-ffd9-4c0a-8da0-0558116b27d5", false, "turnosagendar@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "a959c4ec-7dc2-4360-a949-b768669e58ff", "0f85fb0e-2506-4ebd-a55f-c514694fb554" });
        }
    }
}
