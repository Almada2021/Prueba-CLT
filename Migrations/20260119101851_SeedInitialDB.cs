using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace prueba_clt_sa.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "Name", "RateToBase" },
                values: new object[,]
                {
                    { 2, "USD", "Dólar Estadounidense", 7300.0m },
                    { 3, "BRL", "Real Brasileño", 1350.0m },
                    { 4, "ARS", "Peso Argentino", 8.5m },
                    { 5, "EUR", "Euro", 8100.0m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsActive", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "tobias@example.com", true, "Tobias Almada", "hashed_password_1" },
                    { 2, "patricio@example.com", true, "Patricio Lopez", "hashed_password_2" },
                    { 3, "juan@test.com", true, "Juan Perez", "hashed_password_3" },
                    { 4, "maria@test.com", true, "Maria Garcia", "hashed_password_4" },
                    { 5, "carlos@test.com", true, "Carlos Lopez", "hashed_password_5" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Street", "UserId", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Asunción", "Paraguay", "Calle Falsa 123", 1, "9999" },
                    { 2, "Asunción", "Paraguay", "Palma 456", 1, "1001" },
                    { 3, "Santa Rosa", "Paraguay", "Mcal. Estigarribia 789", 2, "6400" },
                    { 4, "Asunción", "Paraguay", "Aviadores del Chaco 321", 3, "1205" },
                    { 5, "Luque", "Paraguay", "Cerro Corá 555", 4, "2060" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
