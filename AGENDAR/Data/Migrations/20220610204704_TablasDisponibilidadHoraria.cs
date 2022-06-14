using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AGENDAR.Data.Migrations
{
    public partial class TablasDisponibilidadHoraria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisponibilidadHoraria",
                columns: table => new
                {
                    DisponibilidadHorariaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaTurno = table.Column<DateTime>(nullable: false),
                    HorarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisponibilidadHoraria", x => x.DisponibilidadHorariaID);
                    table.ForeignKey(
                        name: "FK_DisponibilidadHoraria_Horario_HorarioID",
                        column: x => x.HorarioID,
                        principalTable: "Horario",
                        principalColumn: "HorarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisponibilidadHoraria_HorarioID",
                table: "DisponibilidadHoraria",
                column: "HorarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisponibilidadHoraria");
        }
    }
}
