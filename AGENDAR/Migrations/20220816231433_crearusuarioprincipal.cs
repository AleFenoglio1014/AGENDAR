using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Migrations
{
    public partial class crearusuarioprincipal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b123868-6f55-48bb-8632-b7959014601b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "19e507b4-da8b-4091-b36c-085e7ae602db", "2356e511-0f58-4c46-9d32-5695f2e612ef" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "281aca7e-79b6-4712-ab5f-15448c3c17b5", "691dea6d-05f1-4edd-a925-8623336c65e7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "65339865-ae2c-489b-8040-129f65a288e8", "691dea6d-05f1-4edd-a925-8623336c65e7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ebd098c6-4d49-46d7-ac60-40ce5cf46717", "691dea6d-05f1-4edd-a925-8623336c65e7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2356e511-0f58-4c46-9d32-5695f2e612ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "691dea6d-05f1-4edd-a925-8623336c65e7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19e507b4-da8b-4091-b36c-085e7ae602db");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "281aca7e-79b6-4712-ab5f-15448c3c17b5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65339865-ae2c-489b-8040-129f65a288e8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebd098c6-4d49-46d7-ac60-40ce5cf46717");

            migrationBuilder.AddColumn<int>(
                name: "TiempoTurnos",
                table: "Horario",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "TiempoTurnos",
                table: "Horario");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2356e511-0f58-4c46-9d32-5695f2e612ef", "942c657e-a216-4e6b-abd3-8226c6440fd4", "SuperUsuario", "SUPERUSUARIO" },
                    { "691dea6d-05f1-4edd-a925-8623336c65e7", "065fad45-df7a-474f-925b-b2ed38fef182", "AdministradorEmpresa", "ADMINISTRADOREMPRESA" },
                    { "1b123868-6f55-48bb-8632-b7959014601b", "4d4d8bfe-6589-462d-8188-f159929f47ac", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "19e507b4-da8b-4091-b36c-085e7ae602db", 0, "bf91f64f-7dfb-4503-8130-2ab3a8971ba2", "ApplicationUser", "turnosagendar@gmail.com", false, false, null, "TURNOSAGENDAR@GMAIL.COM", "TURNOSAGENDAR@GMAIL.COM", "AQAAAAEAACcQAAAAEHqFAslJlzcMxRSASW/0unIxlkousKabwnMme5BZrpSPdQ2e3Kphi+5tWbI4U4KJcQ==", null, false, "b665282c-fe74-465e-a8fc-340d77fd9de5", false, "turnosagendar@gmail.com" },
                    { "65339865-ae2c-489b-8040-129f65a288e8", 0, "1c61ab91-dbbb-4129-b1a3-c491d3d1ad76", "ApplicationUser", "gonza.pagliano@gmail.com", false, false, null, "GONZA.PAGLIANO@GMAIL.COM", "GONZA.PAGLIANO@GMAIL.COM", null, null, false, "659ec851-9e23-4f2b-bc54-3e8bd404ae1f", false, "gonza.pagliano@gmail.com" },
                    { "281aca7e-79b6-4712-ab5f-15448c3c17b5", 0, "926fa877-8ea7-4cdf-b574-4b77ae007bb7", "ApplicationUser", "valentinbeletti.29@gmail.com", false, false, null, "VALENTINBELETTI.29@GMAIL.COM", "VALENTINBELETTI.29@GMAIL.COM", null, null, false, "8e44fa41-5437-4f2d-932f-1df4867a9664", false, "valentinbeletti.29@gmail.com" },
                    { "ebd098c6-4d49-46d7-ac60-40ce5cf46717", 0, "ee37e607-0a51-449e-8c4c-34716f5774ee", "ApplicationUser", "ale.1014f@gmail.com", false, false, null, "ALE.1014F@GMAIL.COM", "ALE.1014F@GMAIL.COM", null, null, false, "d933b1fd-1fc2-42a9-a0f1-399cf5c961e1", false, "ale.1014f@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "19e507b4-da8b-4091-b36c-085e7ae602db", "2356e511-0f58-4c46-9d32-5695f2e612ef" },
                    { "65339865-ae2c-489b-8040-129f65a288e8", "691dea6d-05f1-4edd-a925-8623336c65e7" },
                    { "281aca7e-79b6-4712-ab5f-15448c3c17b5", "691dea6d-05f1-4edd-a925-8623336c65e7" },
                    { "ebd098c6-4d49-46d7-ac60-40ce5cf46717", "691dea6d-05f1-4edd-a925-8623336c65e7" }
                });
        }
    }
}
