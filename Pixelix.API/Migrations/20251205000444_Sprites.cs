using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pixelix.API.Migrations
{
    /// <inheritdoc />
    public partial class Sprites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ee3a0a3-d4fa-4ca6-9399-5be82849a22f", "AQAAAAIAAYagAAAAEBIUqiFIr+q3GZBln8u6JAm4aTbMzmc7pnF4MUCADg9oowTEKb7zNEZX/sT7Raenfw==", "23fd5fc0-d04d-4892-af46-d54861c77ac2" });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 2,
                column: "ValorVenda",
                value: 120.99m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1414c490-893f-44db-9f82-723c9a8b6110", "AQAAAAIAAYagAAAAEEZtDE+yM4fGmYpFq35vCRb13MDyMkJOahiCu7uow35O67zdY0Zdv/ew98q67OtHFQ==", "dea04aa5-f550-4160-b822-348efdf9aaf7" });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 2,
                column: "ValorVenda",
                value: 105.99m);
        }
    }
}
