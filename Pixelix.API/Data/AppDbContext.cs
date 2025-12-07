using Pixelix.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pixelix.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedUsuarioPadrao(builder);
        SeedCategoriaPadrao(builder);
        SeedProdutoPadrao(builder);
    }

    private static void SeedUsuarioPadrao(ModelBuilder builder)
{
    #region Populate Roles
    List<IdentityRole> roles =
    [
        new IdentityRole()
        {
            Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
            Name = "Administrador",
            NormalizedName = "ADMINISTRADOR"
        },
        new IdentityRole()
        {
            Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
            Name = "Cliente",
            NormalizedName = "CLIENTE"
        },
    ];
    builder.Entity<IdentityRole>().HasData(roles);
    #endregion

    #region Populate Usuário
    List<Usuario> usuarios =
    [
        new Usuario()
        {
            Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
            Email = "taynasuperti@gmail.com",
            NormalizedEmail = "TAYNASUPERTI@GMAIL.COM",
            UserName = "taynasuperti@gmail.com",
            NormalizedUserName = "TAYNASUPERTI@GMAIL.COM",
            LockoutEnabled = true,
            EmailConfirmed = true,
            Nome = "Tayná Carolina Miguel Superti",
            DataNascimento = DateTime.Parse("06-11-2006"), // FIXO
            Foto = "/img/usuarios/avatar.png"
        }
    ];

    foreach (var user in usuarios)
    {
        PasswordHasher<Usuario> pass = new();
        user.PasswordHash = pass.HashPassword(user, "123456");
    }

    builder.Entity<Usuario>().HasData(usuarios);
    #endregion

    #region Populate UserRole
    List<IdentityUserRole<string>> userRoles =
    [
        new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            }
    ];
    builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
    #endregion
}

    private static void SeedCategoriaPadrao(ModelBuilder builder)
    {
        List<Categoria> categorias = new()
        {
            // Criar suas categorias
            new Categoria { 
                Id = 1,
                Nome = "Animais", 
                Cor = null, 
                Foto = "/img/categorias/animais/2/pack-gatinhos.jpeg"
            },
            new Categoria { 
                Id = 2, 
                Nome = "Blocos", 
                Cor = null, 
                Foto = "/img/categorias/blocos/4/portal.jpeg" 
            },
            new Categoria { 
                Id = 3, 
                Nome = "Cenários", 
                Cor = null, 
                Foto = "/img/categorias/cenarios/1/cenario-coinquest.jpeg" 
            },
            new Categoria { 
                Id = 4, 
                Nome = "Comidas", 
                Cor = null, 
                Foto = "/img/categorias/comidas/2/pack-doces.jpeg"
            },
            new Categoria { 
                Id = 5, 
                Nome = "Itens", 
                Cor = null, 
                Foto = "/img/categorias/itens/1/pack-pocoes.jpeg"
            },
            new Categoria { 
                Id = 6, 
                Nome = "Personagens", 
                Cor = null, 
                Foto = "/img/categorias/personagens/8/pack-fadinhas.jpeg"
            }
        };
        builder.Entity<Categoria>().HasData(categorias);
    }

    private static void SeedProdutoPadrao(ModelBuilder builder)
    {
        List<Produto> produtos = new()
        {
            // Criar seus produtos
            new Produto
            {
                Id = 1,
                CategoriaId = 1, // Animais
                Nome = "Pack Fazendinha",
                Descricao = "Pack de animais para montar sua fazendinha em pixel art.",
                Qtde = 10,
                ValorCusto = 0m,
                ValorVenda = 205.99m,
                Destaque = false,
                Foto = "/img/categorias/animais/1/pack-fazendinha.jpeg"
            },
            new Produto
            {
                Id = 2,
                CategoriaId = 1, // Animais
                Nome = "Pack Gatinhos",
                Descricao = "Pack de gatinhos fofinhos em pixel art.",
                Qtde = 10,
                ValorCusto = 0m,
                ValorVenda = 120.99m,
                Destaque = false,
                Foto = "/img/categorias/animais/2/pack-gatinhos.jpeg"
            },
            new Produto
            {
                Id = 3,
                CategoriaId = 1, // Animais
                Nome = "Pack Pássaros",
                Descricao = "Pack de passarinhos em pixel art.",
                Qtde = 10,
                ValorCusto = 0m,
                ValorVenda = 135.99m,
                Destaque = false,
                Foto = "/img/categorias/animais/3/pack-passaros.jpeg"
            },
            new Produto
            {
                Id = 4,
                CategoriaId = 1, // Animais
                Nome = "Pack de Animais Silvestres",
                Descricao = "Pack de animais silvestres em pixel art.",
                Qtde = 10,
                ValorCusto = 0m,
                ValorVenda = 105.99m,
                Destaque = false,
                Foto = "/img/categorias/animais/4/pack-silvestre.jpeg"
            },
            // blocos
            new Produto
            {
                Id = 5,
                CategoriaId = 2, // Blocos
                Nome = "Pack de Blocos de Flores",
                Descricao = "Pack de diversas flores em pixel art.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 80.99m,
                Destaque = false,
                Foto = "/img/categorias/blocos/1/pack-blocoflores.jpeg"
            },
            new Produto
            {
                Id = 6,
                CategoriaId = 2, // Blocos
                Nome = "Pack de Blocos e Elementos",
                Descricao = "Pack de blocos de elementos em pixel art.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 90.99m,
                Destaque = false,
                Foto = "/img/categorias/blocos/2/pack-blocoselementos.jpeg"
            },
            new Produto
            {
                Id = 7,
                CategoriaId = 2, // Blocos
                Nome = "Pack de Blocos de Grama",
                Descricao = "Pack de grama em pixel art.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 80.99m,
                Destaque = false,
                Foto = "/img/categorias/blocos/3/pack-blocosgrama.jpeg"
            },
            new Produto
            {
                Id = 8,
                CategoriaId = 2, // Blocos
                Nome = "Portal Mágico",
                Descricao = "Sprite de portal mágico para seu jogo.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 180.99m,
                Destaque = false,
                Foto = "/img/categorias/blocos/4/portal.jpeg"
            },
            // cenarios
            new Produto
            {
                Id = 9,
                CategoriaId = 3, //  Cenários
                Nome = "Cenário Completo CoinQuest",
                Descricao = "Cenário em pixel art do jogo CoinQuest.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 250.99m,
                Destaque = false,
                Foto = "/img/categorias/cenarios/1/cenario-coinquest.jpeg"
            },
            new Produto
            {
                Id = 10,
                CategoriaId = 3, // Cenários
                Nome = "Cenário Completo de Hora de Aventura",
                Descricao = "Cenário em pixel art do desenho Hora de Aventura.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 280.99m,
                Destaque = false,
                Foto = "/img/categorias/cenarios/2/cenario-horadeaventura.jpeg"
            },
            new Produto
            {
                Id = 11,
                CategoriaId = 3, // Cenários
                Nome = "Cenário Completo de Mystery Hack",
                Descricao = "Cenário em pixel art do desenho Mystery Hack.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 280.99m,
                Destaque = false,
                Foto = "/img/categorias/cenarios/3/cenario-mysteryhack.jpeg"
            },
            // comidas
            new Produto
            {
                Id = 12,
                CategoriaId = 4, // Comidas
                Nome = "Pack de Comidas Diversas",
                Descricao = "Pack de comidas 2D + de 130 sprites deliciosos!.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 120.99m,
                Destaque = false,
                Foto = "/img/categorias/comidas/1/pack-comidas.jpeg"
            },
            new Produto
            {
                Id = 13,
                CategoriaId = 4, // Comidas
                Nome = "Pack de Doces Diversos",
                Descricao = "Pack de doces e sobremesas 2D + de 130 sprites deliciosos!.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 120.99m,
                Destaque = false,
                Foto = "/img/categorias/comidas/2/pack-doces.jpeg"
            },
            // itens
            new Produto
            {
                Id = 14,
                CategoriaId = 5, // Itens
                Nome = "Pack de Poções",
                Descricao = "Pack de poções mágicas em pixel art.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 115.99m,
                Destaque = false,
                Foto = "/img/categorias/itens/1/pack-pocoes.jpeg"
            },
        //    personagens
        new Produto
            {
                Id = 15,
                CategoriaId = 6, // Personagens
                Nome = "Pack de Fadinha",
                Descricao = "Pack de personagem fada em pixel art.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 180.99m,
                Destaque = true,
                Foto = "/img/categorias/personagens/1/pack-fadinha.jpeg"
            },
            new Produto
            {
                Id = 16,
                CategoriaId = 6, // Personagens
                Nome = "Pack de Globin",
                Descricao = "Pack de personagem globin em pixel art.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 180.99m,
                Destaque = true,
                Foto = "/img/categorias/personagens/2/pack-globin.jpeg"
            },
            new Produto
            {
                Id = 17,
                CategoriaId = 6, // Personagens
                Nome = "Pack de Mago",
                Descricao = "Pack de personagem mago em pixel art.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 180.99m,
                Destaque = true,
                Foto = "/img/categorias/personagens/3/pack-mago.jpeg"
            },
            new Produto
            {
                Id = 18,
                CategoriaId = 6, // Personagens
                Nome = "Pack de Personagem Feminina",
                Descricao = "Pack de personagem feminina em pixel art.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 150.99m,
                Destaque = true,
                Foto = "/img/categorias/personagens/4/pack-menina.jpeg"
            },
            new Produto
            {
                Id = 19,
                CategoriaId = 6, // Personagens
                Nome = "Pack de Personagem Masculino",
                Descricao = "Pack de personagem masculino em pixel art.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 150.99m,
                Destaque = true,
                Foto = "/img/categorias/personagens/5/pack-menino.jpeg"
            },
            new Produto
            {
                Id = 20,
                CategoriaId = 6, // Personagens
                Nome = "Pack de Vilão",
                Descricao = "Pack de personagem vilão em pixel art.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 180.99m,
                Destaque = true,
                Foto = "/img/categorias/personagens/6/pack-vilao.jpeg"
            },
            new Produto
            {
                Id = 21,
                CategoriaId = 6, // Personagens
                Nome = "Pack Bruxa Pixel Art",
                Descricao = "Pack de personagem bruxa em pixel art.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 150.99m,
                Destaque = false,
                Foto = "/img/categorias/personagens/7/pack-bruxas.jpeg"
            },
            new Produto
            {
                Id = 22,
                CategoriaId = 6, // Personagens
                Nome = "Pack Fadinhas Pixel Art",
                Descricao = "Pack de personagem fadinhas em pixel art.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 150.99m,
                Destaque = false,
                Foto = "/img/categorias/personagens/8/pack-fadinhas.jpeg"
            }
        };
        builder.Entity<Produto>().HasData(produtos);
    }

}