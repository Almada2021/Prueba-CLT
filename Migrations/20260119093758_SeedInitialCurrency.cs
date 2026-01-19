using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prueba_clt_sa.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "Name", "RateToBase" },
                values: new object[] { 1, "PYG", "Guaraní Paraguayo", 1.0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
