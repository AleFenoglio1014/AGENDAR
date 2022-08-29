using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Migrations
{
    public partial class relacionHorario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7300519a-2919-4e3d-a78f-492fee8e0178", "ff465b77-9459-4667-a5ce-fc687c59279d", "SuperUsuario", "SUPERUSUARIO" },
                    { "acc98425-3772-4620-abd9-12802ce4e8ed", "aa1adcfe-362a-4bec-ad56-d4cfd73bb427", "AdministradorEmpresa", "ADMINISTRADOREMPRESA" },
                    { "cd8878e8-ef35-4a5f-bd52-1a4fb4d4b458", "a51fa9f0-2dff-4917-b6d6-cb4d01680edc", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2890bc15-1888-4bc7-8e27-ab620ba25a48", 0, "b148baf1-632e-462a-9923-8118f23b5e26", "ApplicationUser", "turnosagendar@gmail.com", false, false, null, "TURNOSAGENDAR@GMAIL.COM", "TURNOSAGENDAR@GMAIL.COM", "AQAAAAEAACcQAAAAED+TEE1iWTIRZsEzsv4TjSEQuHUZeaxfS33rPaPtj18pPPDaVFDH+WfFBFfATxo8TA==", null, false, "0c0f6533-4605-4af0-863c-07a81e872b60", false, "turnosagendar@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2890bc15-1888-4bc7-8e27-ab620ba25a48", "7300519a-2919-4e3d-a78f-492fee8e0178" });

            migrationBuilder.CreateIndex(
                name: "IX_Horario_ProfesionalID",
                table: "Horario",
                column: "ProfesionalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Horario_Profesional_ProfesionalID",
                table: "Horario",
                column: "ProfesionalID",
                principalTable: "Profesional",
                principalColumn: "ProfesionalID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Horario_Profesional_ProfesionalID",
                table: "Horario");

            migrationBuilder.DropIndex(
                name: "IX_Horario_ProfesionalID",
                table: "Horario");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acc98425-3772-4620-abd9-12802ce4e8ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd8878e8-ef35-4a5f-bd52-1a4fb4d4b458");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2890bc15-1888-4bc7-8e27-ab620ba25a48", "7300519a-2919-4e3d-a78f-492fee8e0178" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7300519a-2919-4e3d-a78f-492fee8e0178");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2890bc15-1888-4bc7-8e27-ab620ba25a48");

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
    }
}
