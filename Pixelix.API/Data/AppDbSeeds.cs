using Pixelix.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Pixelix.API.Data;

public static class AppDbSeeds
{
    // -------------------------------------------------------------
    // CATEGORIAS PADRÃO
    // -------------------------------------------------------------
    public static void SeedCategorias(ModelBuilder builder)
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
                Descricao = "Pack de animais para montar sua fazendinha em pixel art.",
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
                Nome = "Pack Gatinhos",
                Descricao = "Pack de gatinhos fofinhos em pixel art.",
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
                Nome = "Pack Pássaros",
                Descricao = "Pack de passarinhos em pixel art.",
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
                Nome = "Pack de Animais Silvestres",
                Descricao = "Pack de animais silvestres em pixel art.",
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
                Nome = "Pack de Blocos de Flores",
                Descricao = "Pack de diversas flores em pixel art.",
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
                Nome = "Pack de Blocos e Elementos",
                Descricao = "Pack de blocos de elementos em pixel art.",
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
                Nome = "Pack de Blocos de Grama",
                Descricao = "Pack de grama em pixel art.",
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
                Nome = "Portal Mágico",
                Descricao = "Sprite de portal mágico para seu jogo.",
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
                Nome = "Cenário Completo CoinQuest",
                Descricao = "Cenário em pixel art do jogo CoinQuest.",
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
                Nome = "Cenário Completo de Hora de Aventura",
                Descricao = "Cenário em pixel art do desenho Hora de Aventura.",
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
                Nome = "Cenário Completo de Mystery Hack",
                Descricao = "Cenário em pixel art do desenho Mystery Hack.",
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
                Nome = "Pack de Comidas Diversas",
                Descricao = "Pack de comidas 2D + de 130 sprites deliciosos!.",
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
                Nome = "Pack de Doces Diversos",
                Descricao = "Pack de doces e sobremesas 2D + de 130 sprites deliciosos!.",
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
                Nome = "Pack de Poções",
                Descricao = "Pack de poções mágicas em pixel art.",
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
                Nome = "Pack de Fadinha",
                Descricao = "Pack de personagem fada em pixel art.",
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
                Nome = "Pack de Globin",
                Descricao = "Pack de personagem globin em pixel art.",
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
                Nome = "Pack de Mago",
                Descricao = "Pack de personagem mago em pixel art.",
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
                Nome = "Pack de Personagem Feminina",
                Descricao = "Pack de personagem feminina em pixel art.",
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
                Nome = "Pack de Personagem Masculino",
                Descricao = "Pack de personagem masculino em pixel art.",
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
                Nome = "Pack de Vilão",
                Descricao = "Pack de personagem vilão em pixel art.",
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
                Nome = "Pack Bruxa Pixel Art",
                Descricao = "Pack de personagem bruxa em pixel art.",
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
                Nome = "Pack Fadinhas Pixel Art",
                Descricao = "Pack de personagem fadinhas em pixel art.",
                Qtde = 5,
                ValorCusto = 0m,
                ValorVenda = 8.99m,
                Destaque = false,
                Foto = "/img/categorias/personagens/8/pack-fadinhas.jpeg"
            } 
        );
    }
}