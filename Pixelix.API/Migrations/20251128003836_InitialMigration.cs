using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pixelix.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Foto = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Foto = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cor = table.Column<string>(type: "varchar(26)", maxLength: 26, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Qtde = table.Column<int>(type: "int", nullable: false),
                    ValorCusto = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    ValorVenda = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Destaque = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Foto = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b44ca04-f6b0-4a8f-a953-1f2330d30894", null, "Administrador", "ADMINISTRADOR" },
                    { "ddf093a6-6cb5-4ff7-9a64-83da34aee005", null, "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DataNascimento", "Email", "EmailConfirmed", "Foto", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ddf093a6-6cb5-4ff7-9a64-83da34aee005", 0, "e679a0ba-4522-4824-b172-9b62b993c126", new DateTime(2006, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "taynasuperti@gmail.com", true, "/img/usuarios/avatar.png", true, null, "Tayná Carolina Miguel Superti", "TAYNASUPERTI@GMAIL.COM", "TAYNASUPERTI@GMAIL.COM", "AQAAAAIAAYagAAAAEMJvVcRjKBfMnatcEgG4k3eroRazNuSeyTeGeI8f+2XH0bGlhETfIMHf8EJPgpOMNA==", null, false, "8f4e1b60-7626-4ab8-8ffb-d50bd867b117", false, "taynasuperti@gmail.com" });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Cor", "Foto", "Nome" },
                values: new object[,]
                {
                    { 1, null, null, "Animais" },
                    { 2, null, null, "Blocos" },
                    { 3, null, null, "Cenários" },
                    { 4, null, null, "Comidas" },
                    { 5, null, null, "Itens" },
                    { 6, null, null, "Personagens" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0b44ca04-f6b0-4a8f-a953-1f2330d30894", "ddf093a6-6cb5-4ff7-9a64-83da34aee005" });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "CategoriaId", "Descricao", "Destaque", "Foto", "Nome", "Qtde", "ValorCusto", "ValorVenda" },
                values: new object[,]
                {
                    { 1, 1, "Pack de animais para montar sua fazendinha em pixel art.", true, "/img/categorias/animais/1/pack-fazendinha.jpeg", "Pack Fazendinha", 10, 0m, 5.99m },
                    { 2, 1, "Pack de gatinhos fofinhos em pixel art.", true, "/img/categorias/animais/2/pack-gatinhos.jpeg", "Pack Gatinhos", 10, 0m, 5.99m },
                    { 3, 1, "Pack de passarinhos em pixel art.", true, "/img/categorias/animais/3/pack-passaros.jpeg", "Pack Pássaros", 10, 0m, 5.99m },
                    { 4, 1, "Pack de animais silvestres em pixel art.", false, "/img/categorias/animais/4/pack/silvestre.jpeg", "Pack de Animais Silvestres", 10, 0m, 5.99m },
                    { 5, 2, "Pack de diversas flores em pixel art.", false, "/img/categorias/blocos/1/pack-blocoflores.jpeg", "Pack de Blocos de Flores", 5, 0m, 8.99m },
                    { 6, 2, "Pack de blocos de elementos em pixel art.", false, "/img/categorias/blocos/2/pack-blocoseslementos.jpeg", "Pack de Blocos e Elementos", 5, 0m, 8.99m },
                    { 7, 2, "Pack de grama em pixel art.", false, "/img/categorias/blocos/3/pack-blocosgrama.jpeg", "Pack de Blocos de Grama", 5, 0m, 8.99m },
                    { 8, 2, "Sprite de portal mágico para seu jogo.", false, "/img/categorias/blocos/4/portal.jpeg", "Portal Mágico", 5, 0m, 8.99m },
                    { 9, 3, "Cenário em pixel art do jogo CoinQuest.", false, "/img/categorias/cenarios/1/cenario-coinquest.jpeg", "Cenário Completo CoinQuest", 5, 0m, 8.99m },
                    { 10, 3, "Cenário em pixel art do desenho Hora de Aventura.", false, "/img/categorias/cenarios/2/cenario-horadeaventura.jpeg", "Cenário Completo de Hora de Aventura", 5, 0m, 8.99m },
                    { 11, 3, "Cenário em pixel art do desenho Mystery Hack.", false, "/img/categorias/cenarios/3/cenario-mysteryhack.jpeg", "Cenário Completo de Mystery Hack", 5, 0m, 8.99m },
                    { 12, 4, "Pack de comidas 2D + de 130 sprites deliciosos!.", false, "/img/categorias/comidas/1/pack-comidas.jpeg", "Pack de Comidas Diversas", 5, 0m, 8.99m },
                    { 13, 4, "Pack de doces e sobremesas 2D + de 130 sprites deliciosos!.", false, "/img/categorias/comidas/2/pack-doces.jpeg", "Pack de Doces Diversos", 5, 0m, 8.99m },
                    { 14, 5, "Pack de poções mágicas em pixel art.", false, "/img/categorias/itens/1/pack-pocoes.jpeg", "Pack de Poções", 5, 0m, 8.99m },
                    { 15, 6, "Pack de personagem fada em pixel art.", false, "/img/categorias/personagens/1/fadinha-frente.jpeg", "Pack de Fadinha", 5, 0m, 8.99m },
                    { 16, 6, "Pack de personagem globin em pixel art.", false, "/img/categorias/personagens/2/globin-frente.jpeg", "Pack de Globin", 5, 0m, 8.99m },
                    { 17, 6, "Pack de personagem mago em pixel art.", false, "/img/categorias/personagens/3/mago-frente.jpeg", "Pack de Mago", 5, 0m, 8.99m },
                    { 18, 6, "Pack de personagem feminina em pixel art.", false, "/img/categorias/personagens/4/menina-frente.jpeg", "Pack de Personagem Feminina", 5, 0m, 8.99m },
                    { 19, 6, "Pack de personagem masculino em pixel art.", false, "/img/categorias/personagens/5/menino-frente.jpeg", "Pack de Personagem Masculino", 5, 0m, 8.99m },
                    { 20, 6, "Pack de personagem vilão em pixel art.", false, "/img/categorias/personagens/6/vilao-frente.jpeg", "Pack de Vilão", 5, 0m, 8.99m },
                    { 21, 6, "Pack de personagem bruxa em pixel art.", false, "/img/categorias/personagens/7/pack-bruxas.jpeg", "Pack Bruxa Pixel Art", 5, 0m, 8.99m },
                    { 22, 6, "Pack de personagem fadinhas em pixel art.", false, "/img/categorias/personagens/8/pack-fadinhas.jpeg", "Pack Fadinhas Pixel Art", 5, 0m, 8.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
