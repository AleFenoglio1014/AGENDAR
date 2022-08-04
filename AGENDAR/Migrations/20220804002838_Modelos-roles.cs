using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Migrations
{
    public partial class Modelosroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
