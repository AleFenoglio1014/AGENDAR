using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Migrations
{
    public partial class ImagenEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaID",
                table: "Horario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "ImagenEmpresa",
                table: "Empresa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagenEmpresaString",
                table: "Empresa",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpresaID",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "ImagenEmpresa",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "ImagenEmpresaString",
                table: "Empresa");
        }
    }
}
