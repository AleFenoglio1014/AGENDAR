using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Migrations
{
    public partial class RolesAdministradorGmailPropios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a01a689a-b0d7-4616-837c-6b167ba77f6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9768c9a-e0ef-4b57-aded-ca805023d0ee");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "2fb278e4-ca78-46b4-a48c-13f670e0208b", "eac71dfb-c6b9-4862-b5d3-d23489aa96bb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eac71dfb-c6b9-4862-b5d3-d23489aa96bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2fb278e4-ca78-46b4-a48c-13f670e0208b");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "eac71dfb-c6b9-4862-b5d3-d23489aa96bb", "59b3752d-a84c-4ae1-999a-7a9f028ddfd0", "SuperUsuario", "SUPERUSUARIO" },
                    { "f9768c9a-e0ef-4b57-aded-ca805023d0ee", "9ddd8c88-1db6-4c07-a297-d366858a500b", "AdministradorEmpresa", "ADMINISTRADOREMPRESA" },
                    { "a01a689a-b0d7-4616-837c-6b167ba77f6c", "22862f61-6543-4df4-8b28-c13a669c61e9", "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2fb278e4-ca78-46b4-a48c-13f670e0208b", 0, "646cc6ee-dc9b-4e17-bce8-c6c19f6c6aa9", "ApplicationUser", "turnosagendar@gmail.com", false, false, null, "TURNOSAGENDAR@GMAIL.COM", "TURNOSAGENDAR@GMAIL.COM", "AQAAAAEAACcQAAAAENGTdDibW6tqe1Z9gHKeocGRqV/t9nc9d05doH/e9iCOCc5yEZNnAwC0gxHgHrZS1w==", null, false, "d9bc35ca-b1bc-482d-a419-cf925a5ffefc", false, "turnosagendar@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "2fb278e4-ca78-46b4-a48c-13f670e0208b", "eac71dfb-c6b9-4862-b5d3-d23489aa96bb" });
        }
    }
}
