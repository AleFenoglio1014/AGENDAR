using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Migrations
{
    public partial class RolesAdministradorGonzaValeAle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3e369de-a130-4903-9846-53fa5c534e72");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2a7bade7-cebb-4162-a264-9c08b9237816", "dcb8501d-f0fa-4770-89bf-38282a8cedf7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "38c44773-7cde-4db0-9bf5-568ceebdc20a", "a03459be-dcc8-4b9d-bc14-5d79546065fe" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "4f3059e0-b768-4be8-b0d0-98390f846674", "a03459be-dcc8-4b9d-bc14-5d79546065fe" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "68d89b0c-28d3-4a5e-8470-e08ac4eed153", "a03459be-dcc8-4b9d-bc14-5d79546065fe" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a03459be-dcc8-4b9d-bc14-5d79546065fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcb8501d-f0fa-4770-89bf-38282a8cedf7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a7bade7-cebb-4162-a264-9c08b9237816");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "38c44773-7cde-4db0-9bf5-568ceebdc20a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f3059e0-b768-4be8-b0d0-98390f846674");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "68d89b0c-28d3-4a5e-8470-e08ac4eed153");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dcb8501d-f0fa-4770-89bf-38282a8cedf7", "ba4b43c6-fbd1-4c43-b638-e03856e1f234", "SuperUsuario", "SUPERUSUARIO" },
                    { "a03459be-dcc8-4b9d-bc14-5d79546065fe", "94fba6d4-98ff-472f-8734-2b5bb2288f69", "AdministradorEmpresa", "ADMINISTRADOREMPRESA" },
                    { "a3e369de-a130-4903-9846-53fa5c534e72", "2b7cc990-d771-4a80-a2a5-f8cfda975603", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2a7bade7-cebb-4162-a264-9c08b9237816", 0, "ce45b1a9-a3f3-408f-ad44-119808baa8bc", "ApplicationUser", "turnosagendar@gmail.com", false, false, null, "TURNOSAGENDAR@GMAIL.COM", "TURNOSAGENDAR@GMAIL.COM", "AQAAAAEAACcQAAAAEEnkCZL3x59Kps1OT6GpBwmF1MUfw0AkcqaeEwcxBcz4EwAVrUBmtt/sV2Hsk2fFHA==", null, false, "7ab50eef-7850-4298-b12e-4464d8eec4a0", false, "turnosagendar@gmail.com" },
                    { "4f3059e0-b768-4be8-b0d0-98390f846674", 0, "aabad448-f87d-482d-ad9a-ad9422197fa5", "ApplicationUser", "gonza.pagliano@gmail.com", false, false, null, "GONZA.PAGLIANO@GMAIL.COM", "GONZA.PAGLIANO@GMAIL.COM", null, null, false, "2707b167-25ae-456c-bb9d-0dfff78ddfb4", false, "gonza.pagliano@gmail.com" },
                    { "68d89b0c-28d3-4a5e-8470-e08ac4eed153", 0, "a69882a8-3703-40cd-a60e-3bf3e49befce", "ApplicationUser", "valentinbeletti.29@gmail.com", false, false, null, "VALENTINBELETTI.29@GMAIL.COM", "VALENTINBELETTI.29@GMAIL.COM", null, null, false, "e3041b24-30a4-4b60-bfdf-6778799b25f6", false, "valentinbeletti.29@gmail.com" },
                    { "38c44773-7cde-4db0-9bf5-568ceebdc20a", 0, "b5a4dcca-ea94-42b9-a4a8-946cbf309cfd", "ApplicationUser", "ale.1014f@gmail.com", false, false, null, "ALE.1014F@GMAIL.COM", "ALE.1014F@GMAIL.COM", null, null, false, "7e60c560-435c-4eca-ac3e-c1a228f2f83f", false, "ale.1014f@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "2a7bade7-cebb-4162-a264-9c08b9237816", "dcb8501d-f0fa-4770-89bf-38282a8cedf7" },
                    { "4f3059e0-b768-4be8-b0d0-98390f846674", "a03459be-dcc8-4b9d-bc14-5d79546065fe" },
                    { "68d89b0c-28d3-4a5e-8470-e08ac4eed153", "a03459be-dcc8-4b9d-bc14-5d79546065fe" },
                    { "38c44773-7cde-4db0-9bf5-568ceebdc20a", "a03459be-dcc8-4b9d-bc14-5d79546065fe" }
                });
        }
    }
}
