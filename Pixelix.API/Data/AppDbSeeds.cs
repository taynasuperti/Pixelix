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

        SeedRoles(builder);
        SeedAdminUser(builder);
        SeedCategorias(builder);
        SeedProdutos(builder);
    }

    // -------------------------------------------------------------
    // ROLES
    // -------------------------------------------------------------
    private static void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "role-admin-0001",
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole
            {
                Id = "role-cliente-0001",
                Name = "Cliente",
                NormalizedName = "CLIENTE"
            }
        );
    }

    // -------------------------------------------------------------
    // ADMIN USER
    // -------------------------------------------------------------
    private static void SeedAdminUser(ModelBuilder builder)
    {
        var admin = new Usuario
        {
            Id = "user-admin-0001",
            Email = "taynasuperti@gmail.com",
            NormalizedEmail = "TAYNASUPERTI@GMAIL.COM",
            UserName = "taynasuperti@gmail.com",
            NormalizedUserName = "TAYNASUPERTI@GMAIL.COM",
            Nome = "Tayná Carolina Miguel Superti",
            EmailConfirmed = true,
            Foto = "/img/usuarios/avatar.png",
            LockoutEnabled = false,
            DataNascimento = DateTime.Parse("2006-11-06")
        };

        var hasher = new PasswordHasher<Usuario>();
        admin.PasswordHash = hasher.HashPassword(admin, "123456");

        builder.Entity<Usuario>().HasData(admin);

        // Vincular ao role Administrador
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                UserId = "user-admin-0001",
                RoleId = "role-admin-0001"
            }
        );
    }

    // -------------------------------------------------------------
    // CATEGORIAS PADRÃO
    // -------------------------------------------------------------
    private static void SeedCategorias(ModelBuilder builder)
    {
        builder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nome = "Animais", Foto = null, Cor = null },
            new Categoria { Id = 2, Nome = "Blocos", Foto = null, Cor = null },
            new Categoria { Id = 3, Nome = "Cenários", Foto = null, Cor = null },
            new Categoria { Id = 4, Nome = "Comidas", Foto = null, Cor = null },
            new Categoria { Id = 5, Nome = "Itens", Foto = null, Cor = null },
            new Categoria { Id = 6, Nome = "Personagens", Foto = null, Cor = null }
        );
    }

    // -------------------------------------------------------------
    // PRODUTOS PADRÃO (EXEMPLOS)
    // -------------------------------------------------------------
    private static void SeedProdutos(ModelBuilder builder)
    {
        builder.Entity<Produto>().HasData(
            // animais
            new Produto
            {
                Id = 1,
                CategoriaId = 1, // Animais
                Nome = "Pack Fazendinha",
                Descricao = "Sprite de um gatinho fofo em pixel art.",
                Qtde = 10,
                ValorCusto = 0m,
                ValorVenda = 5.99m,
                Destaque = true,
                Foto = "/img/categorias/animais/1/pack-fazendinha.jpeg"
            },
            new Produto
            {
                Id = 2,
                CategoriaId = 1, // Animais
                Nome = "Gatinho Pixel Art",
                Descricao = "Sprite de um gatinho fofo em pixel art.",
                Qtde = 10,
                ValorCusto = 0m,
                ValorVenda = 5.99m,
                Destaque = true,
                Foto = "/img/categorias/animais/2/pack-gatinhos.jpeg"
            },
            new Produto
            {
                Id = 3,
                CategoriaId = 1, // Animais
                Nome = "Gatinho Pixel Art",
                Descricao = "Sprite de um gatinho fofo em pixel art.",
                Qtde = 10,
                ValorCusto = 0m,
                ValorVenda = 5.99m,
                Destaque = true,
                Foto = "/img/categorias/animais/3/pack-passaros.jpeg"
            },
            new Produto
            {
                Id = 4,
                CategoriaId = 1, // Animais
                Nome = "Gatinho Pixel Art",
                Descricao = "Sprite de um gatinho fofo em pixel art.",
                Qtde = 10,
                ValorCusto = 0m,
                ValorVenda = 5.99m,
                Destaque = true,
                Foto = "/img/categorias/animais/4/pack/silvestre.jpeg"
            },
            // blocos
            new Produto
            {
                Id = 5,
                CategoriaId = 2, // Blocos
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/blocos/1/pack-blocoflores.jpeg"
            },
            new Produto
            {
                Id = 6,
                CategoriaId = 2, // Blocos
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/blocos/2/pack-blocoseslementos.jpeg"
            },
            new Produto
            {
                Id = 7,
                CategoriaId = 2, // Blocos
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/blocos/3/pack-blocosgrama.jpeg"
            },
            new Produto
            {
                Id = 8,
                CategoriaId = 2, // Blocos
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/blocos/4/portal.jpeg"
            },
            // cenarios
            new Produto
            {
                Id = 9,
                CategoriaId = 3, //  Cenários
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/cenarios/1/cenario-coinquest.jpeg"
            },
            new Produto
            {
                Id = 10,
                CategoriaId = 3, // Cenários
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/cenarios/2/cenario-horadeaventura.jpeg"
            },
            new Produto
            {
                Id = 11,
                CategoriaId = 3, // Cenários
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/cenarios/3/cenario-mysteryhack.jpeg"
            },
            // comidas
            new Produto
            {
                Id = 12,
                CategoriaId = 4, // Comidas
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/comidas/1/pack-comidas.jpeg"
            },
            new Produto
            {
                Id = 13,
                CategoriaId = 4, // Comidas
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/comidas/2/pack-doces.jpeg"
            },
            // itens
            new Produto
            {
                Id = 14,
                CategoriaId = 5, // Itens
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/itens/1/pack-pocoes.jpeg"
            },
        //    personagens
        new Produto
            {
                Id = 15,
                CategoriaId = 6, // Personagens
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/personagens/1/fadinha-frente.jpeg"
            },
            new Produto
            {
                Id = 16,
                CategoriaId = 6, // Personagens
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/personagens/2/globin-frente.jpeg"
            },
            new Produto
            {
                Id = 17,
                CategoriaId = 6, // Personagens
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/personagens/3/mago-frente.jpeg"
            },
            new Produto
            {
                Id = 18,
                CategoriaId = 6, // Personagens
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/personagens/4/menina-frente.jpeg"
            },
            new Produto
            {
                Id = 19,
                CategoriaId = 6, // Personagens
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/personagens/5/menino-frente.jpeg"
            },
            new Produto
            {
                Id = 20,
                CategoriaId = 6, // Personagens
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/personagens/6/vilao-frente.jpeg"
            },
            new Produto
            {
                Id = 21,
                CategoriaId = 6, // Personagens
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/personagens/7/pack-bruxas.jpeg"
            },
            new Produto
            {
                Id = 22,
                CategoriaId = 6, // Personagens
                Nome = "Heroína Pixel Art",
                Descricao = "Sprite de personagem feminina estilo 16-bits.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/personagens/8/pack-fadinhas.jpeg"
            } 
        );
    }
}
