using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiABPD.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Partia",
                columns: new[] { "ID", "DataZalozenia", "Nazwa", "Skrot" },
                values: new object[] { 99, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Partia Przykladowa", "PP" });

            migrationBuilder.InsertData(
                table: "Polityk",
                columns: new[] { "ID", "Imie", "Nazwisko", "Powiedzenie" },
                values: new object[] { 99, "Jan", "Kowalski", "Obywatelu, spokojnie!" });

            migrationBuilder.InsertData(
                table: "Przynaleznosc",
                columns: new[] { "ID", "Do", "Od", "Partia_ID", "Polityk_ID" },
                values: new object[] { 99, null, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 99 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Przynaleznosc",
                keyColumn: "ID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Partia",
                keyColumn: "ID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Polityk",
                keyColumn: "ID",
                keyValue: 99);
        }
    }
}
