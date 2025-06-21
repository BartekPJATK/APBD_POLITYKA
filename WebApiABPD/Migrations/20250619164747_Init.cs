using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiABPD.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partia",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Skrot = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DataZalozenia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partia", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Polityk",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Powiedzenie = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polityk", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Przynaleznosc",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Partia_ID = table.Column<int>(type: "int", nullable: false),
                    Polityk_ID = table.Column<int>(type: "int", nullable: false),
                    Od = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Do = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przynaleznosc", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Przynaleznosc_Partia_Partia_ID",
                        column: x => x.Partia_ID,
                        principalTable: "Partia",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Przynaleznosc_Polityk_Polityk_ID",
                        column: x => x.Polityk_ID,
                        principalTable: "Polityk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Przynaleznosc_Partia_ID",
                table: "Przynaleznosc",
                column: "Partia_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Przynaleznosc_Polityk_ID",
                table: "Przynaleznosc",
                column: "Polityk_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Przynaleznosc");

            migrationBuilder.DropTable(
                name: "Partia");

            migrationBuilder.DropTable(
                name: "Polityk");
        }
    }
}
