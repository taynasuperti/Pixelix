using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pixelix.API.Migrations
{
    /// <inheritdoc />
    public partial class AddProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 1,
                columns: new[] { "Destaque", "ValorVenda" },
                values: new object[] { false, 205.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Destaque", "ValorVenda" },
                values: new object[] { false, 105.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Destaque", "ValorVenda" },
                values: new object[] { false, 135.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Foto", "ValorVenda" },
                values: new object[] { "/img/categorias/animais/4/pack-silvestre.jpeg", 105.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 5,
                column: "ValorVenda",
                value: 80.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Foto", "ValorVenda" },
                values: new object[] { "/img/categorias/blocos/2/pack-blocoselementos.jpeg", 90.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 7,
                column: "ValorVenda",
                value: 80.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 8,
                column: "ValorVenda",
                value: 180.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 9,
                column: "ValorVenda",
                value: 250.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 10,
                column: "ValorVenda",
                value: 280.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 11,
                column: "ValorVenda",
                value: 280.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 12,
                column: "ValorVenda",
                value: 120.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 13,
                column: "ValorVenda",
                value: 120.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 14,
                column: "ValorVenda",
                value: 115.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Destaque", "Foto", "ValorVenda" },
                values: new object[] { true, "/img/categorias/personagens/1/pack-fadinha.jpeg", 180.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Destaque", "Foto", "ValorVenda" },
                values: new object[] { true, "/img/categorias/personagens/2/pack-globin.jpeg", 180.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Destaque", "Foto", "ValorVenda" },
                values: new object[] { true, "/img/categorias/personagens/3/pack-mago.jpeg", 180.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Destaque", "Foto", "ValorVenda" },
                values: new object[] { true, "/img/categorias/personagens/4/pack-menina.jpeg", 150.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Destaque", "Foto", "ValorVenda" },
                values: new object[] { true, "/img/categorias/personagens/5/pack-menino.jpeg", 150.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Destaque", "Foto", "ValorVenda" },
                values: new object[] { true, "/img/categorias/personagens/6/pack-vilao.jpeg", 180.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 21,
                column: "ValorVenda",
                value: 150.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 22,
                column: "ValorVenda",
                value: 150.99m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71733ef9-5fed-4e31-b163-2227bad1bd7f", "AQAAAAIAAYagAAAAEPWMgqAZdjmQdjblEwpAUDDGUEhArI/PZJ58FNMA8uEuk6jaRhWdan64Sz71dy6NYQ==", "77e8ece1-cfd3-4f49-bccd-d227474e4904" });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Destaque", "ValorVenda" },
                values: new object[] { true, 5.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Destaque", "ValorVenda" },
                values: new object[] { true, 5.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Destaque", "ValorVenda" },
                values: new object[] { true, 5.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Foto", "ValorVenda" },
                values: new object[] { "/img/categorias/animais/4/pack/silvestre.jpeg", 5.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 5,
                column: "ValorVenda",
                value: 8.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Foto", "ValorVenda" },
                values: new object[] { "/img/categorias/blocos/2/pack-blocoseslementos.jpeg", 8.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 7,
                column: "ValorVenda",
                value: 8.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 8,
                column: "ValorVenda",
                value: 8.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 9,
                column: "ValorVenda",
                value: 8.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 10,
                column: "ValorVenda",
                value: 8.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 11,
                column: "ValorVenda",
                value: 8.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 12,
                column: "ValorVenda",
                value: 8.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 13,
                column: "ValorVenda",
                value: 8.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 14,
                column: "ValorVenda",
                value: 8.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Destaque", "Foto", "ValorVenda" },
                values: new object[] { false, "/img/categorias/personagens/1/fadinha-frente.jpeg", 8.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Destaque", "Foto", "ValorVenda" },
                values: new object[] { false, "/img/categorias/personagens/2/globin-frente.jpeg", 8.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Destaque", "Foto", "ValorVenda" },
                values: new object[] { false, "/img/categorias/personagens/3/mago-frente.jpeg", 8.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Destaque", "Foto", "ValorVenda" },
                values: new object[] { false, "/img/categorias/personagens/4/menina-frente.jpeg", 8.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Destaque", "Foto", "ValorVenda" },
                values: new object[] { false, "/img/categorias/personagens/5/menino-frente.jpeg", 8.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Destaque", "Foto", "ValorVenda" },
                values: new object[] { false, "/img/categorias/personagens/6/vilao-frente.jpeg", 8.99m });

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 21,
                column: "ValorVenda",
                value: 8.99m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 22,
                column: "ValorVenda",
                value: 8.99m);
        }
    }
}
