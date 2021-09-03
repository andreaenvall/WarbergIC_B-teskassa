using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WarbergIC_Böteskassa.Migrations
{
    public partial class initiate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nummer = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Regel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pris = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Böter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ÅtalspunktId = table.Column<int>(type: "int", nullable: true),
                    ÅtaladId = table.Column<int>(type: "int", nullable: true),
                    Kommentar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Böter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Böter_Person_ÅtaladId",
                        column: x => x.ÅtaladId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Böter_Regler_ÅtalspunktId",
                        column: x => x.ÅtalspunktId,
                        principalTable: "Regler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Böter_ÅtaladId",
                table: "Böter",
                column: "ÅtaladId");

            migrationBuilder.CreateIndex(
                name: "IX_Böter_ÅtalspunktId",
                table: "Böter",
                column: "ÅtalspunktId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Böter");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Regler");
        }
    }
}
