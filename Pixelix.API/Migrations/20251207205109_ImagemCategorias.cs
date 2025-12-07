using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pixelix.API.Migrations
{
    /// <inheritdoc />
    public partial class ImagemCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f739bb1d-cadd-4f80-973a-3ed63b2cd43f", "AQAAAAIAAYagAAAAENP9FMdkkXSJNCjD9sGvexcyo4q88Aid4Kt06hFdXAClvED5q2XYbfXGHDHFpGC5cw==", "2e848d5d-bc68-4a5c-8a00-ff2174ee9809" });

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1,
                column: "Foto",
                value: "/img/categorias/animais/2/pack-gatinhos.jpeg");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 2,
                column: "Foto",
                value: "/img/categorias/blocos/4/portal.jpeg");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 3,
                column: "Foto",
                value: "/img/categorias/cenarios/1/cenario-coinquest.jpeg");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 4,
                column: "Foto",
                value: "/img/categorias/comidas/2/pack-doces.jpeg");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 5,
                column: "Foto",
                value: "/img/categorias/itens/1/pack-pocoes.jpeg");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 6,
                column: "Foto",
                value: "/img/categorias/personagens/8/pack-fadinhas.jpeg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ee3a0a3-d4fa-4ca6-9399-5be82849a22f", "AQAAAAIAAYagAAAAEBIUqiFIr+q3GZBln8u6JAm4aTbMzmc7pnF4MUCADg9oowTEKb7zNEZX/sT7Raenfw==", "23fd5fc0-d04d-4892-af46-d54861c77ac2" });

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 2,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 3,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 4,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 5,
                column: "Foto",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 6,
                column: "Foto",
                value: null);
        }
    }
}
