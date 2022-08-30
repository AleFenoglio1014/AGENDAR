using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Migrations
{
    public partial class fechaHorario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35633582-a256-4e2e-8272-d8fdd99714ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef824aa5-1474-4eb4-b52a-004e92b0e85b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "00267319-823b-4166-ab5f-15c767349d03", "b020abd0-df82-4b53-9074-734092e44fc9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b020abd0-df82-4b53-9074-734092e44fc9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00267319-823b-4166-ab5f-15c767349d03");

            migrationBuilder.AlterColumn<string>(
                name: "TurnoDias",
                table: "Horario",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e52dd17e-a17b-45f1-a593-f09c1a7d26e7", "ef6698b0-73f8-4f00-8749-e36c94f79301", "SuperUsuario", "SUPERUSUARIO" },
                    { "06c92c6d-8f35-49b0-abbe-963d3d748907", "dad68db0-eda1-4825-ba9d-b7ed543ff5b4", "AdministradorEmpresa", "ADMINISTRADOREMPRESA" },
                    { "8505fac2-e2e6-462d-ba65-a2a58684879b", "2b766605-614d-400f-b727-50e770b3487d", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "376a1bff-819d-428d-95f3-1e84d5c3e0ad", 0, "12a3502c-95e7-42e5-b72f-89fe19cb9ff4", "ApplicationUser", "turnosagendar@gmail.com", false, false, null, "TURNOSAGENDAR@GMAIL.COM", "TURNOSAGENDAR@GMAIL.COM", "AQAAAAEAACcQAAAAEB8W8ZFHhMbVu0XGfUCY0VMmouCBPKAr2cfXmCpr8W0DMdVR2xK4JGiSz2kmHf3PCQ==", null, false, "547910ed-183a-423e-bc9e-cee5710df265", false, "turnosagendar@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "376a1bff-819d-428d-95f3-1e84d5c3e0ad", "e52dd17e-a17b-45f1-a593-f09c1a7d26e7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06c92c6d-8f35-49b0-abbe-963d3d748907");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8505fac2-e2e6-462d-ba65-a2a58684879b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "376a1bff-819d-428d-95f3-1e84d5c3e0ad", "e52dd17e-a17b-45f1-a593-f09c1a7d26e7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e52dd17e-a17b-45f1-a593-f09c1a7d26e7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "376a1bff-819d-428d-95f3-1e84d5c3e0ad");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TurnoDias",
                table: "Horario",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b020abd0-df82-4b53-9074-734092e44fc9", "56a207bc-1648-4cf5-915e-6bd86ae26dee", "SuperUsuario", "SUPERUSUARIO" },
                    { "ef824aa5-1474-4eb4-b52a-004e92b0e85b", "439b3d0b-13aa-406c-b3c1-c774a1fea33c", "AdministradorEmpresa", "ADMINISTRADOREMPRESA" },
                    { "35633582-a256-4e2e-8272-d8fdd99714ef", "29675a28-b95e-4f02-8500-9dc5bcfacc08", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00267319-823b-4166-ab5f-15c767349d03", 0, "2b557616-179a-4578-a79b-c6e6d8bcf7c7", "ApplicationUser", "turnosagendar@gmail.com", false, false, null, "TURNOSAGENDAR@GMAIL.COM", "TURNOSAGENDAR@GMAIL.COM", "AQAAAAEAACcQAAAAEDoWhuEBpdkDwIREe6nLrZEAyEwUsWLOOkCxoEiYEPNS+CWPOk4+z62KyuSaBXo8GQ==", null, false, "ab9bd29b-56bf-4ad2-bffd-67d7593c5add", false, "turnosagendar@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "00267319-823b-4166-ab5f-15c767349d03", "b020abd0-df82-4b53-9074-734092e44fc9" });
        }
    }
}
