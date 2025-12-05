using System.Diagnostics;
using Pixelix.UI.DTOs;
using Pixelix.UI.Models;
using Pixelix.UI.Services.Interfaces;
using Pixelix.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace Pixelix.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ILojaService _lojaService;

    public HomeController(ILogger<HomeController> logger, ILojaService lojaService)
    {
        _logger = logger;
        _lojaService = lojaService;
    }

    // GET: Home/Index - Página inicial
    public async Task<IActionResult> Index()
    {
        try
        {
            var categorias = await _lojaService.ObterCategoriasAtivasAsync();
            var produtosDestaque = await _lojaService.ObterProdutosDestaqueAsync();

            var viewModel = new HomeVM
            {
                Categorias = categorias,
                ProdutosDestaque = produtosDestaque
            };

            return View(viewModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao carregar página inicial");
            return View(new HomeVM());
        }
    }

    // GET: Home/Produtos - Lista de produtos
    public async Task<IActionResult> Produtos(int? categoriaId)
    {
        try
        {
            ViewBag.Categorias = await _lojaService.ObterCategoriasAtivasAsync();

            List<ProdutoDto> produtos;
            if (categoriaId.HasValue && categoriaId > 0)
            {
                produtos = await _lojaService.ObterProdutosPorCategoriaAsync(categoriaId.Value);
                ViewBag.CategoriaSelecionada = categoriaId.Value;
            }
            else
            {
                produtos = await _lojaService.ObterTodosProdutosAsync();
                ViewBag.CategoriaSelecionada = 0;
            }

            return View(produtos);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao carregar produtos da loja");
            TempData["Erro"] = "Erro ao carregar produtos. Tente novamente.";
            return View(new List<ProdutoDto>());
        }
    }

    // GET: Home/Sprites - Tela com todos os sprites e filtros
    public async Task<IActionResult> Sprites(int? categoriaId)
    {
        try
        {
            var categorias = await _lojaService.ObterCategoriasAtivasAsync();
            List<ProdutoDto> produtos;

            if (categoriaId.HasValue && categoriaId > 0)
            {
                produtos = await _lojaService.ObterProdutosPorCategoriaAsync(categoriaId.Value);
                ViewBag.CategoriaSelecionada = categoriaId.Value;
            }
            else
            {
                produtos = await _lojaService.ObterTodosProdutosAsync();
                ViewBag.CategoriaSelecionada = 0;
            }

            var viewModel = new SpritesPageVM
            {
                Categorias = categorias,
                Produtos = produtos
            };

            return View(viewModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao carregar tela de sprites");
            TempData["Erro"] = "Erro ao carregar sprites. Tente novamente.";
            return View(new SpritesPageVM());
        }
    }

    // GET: Home/Detalhes/5 - Detalhes do produto
    public async Task<IActionResult> Detalhes(int id)
    {
        try
        {
            if (id <= 0)
            {
                TempData["Erro"] = "Produto inválido.";
                return RedirectToAction("Produtos");
            }

            var produto = await _lojaService.ObterProdutoPorIdAsync(id);
            if (produto == null)
            {
                TempData["Erro"] = "Produto não encontrado.";
                return RedirectToAction("Produtos");
            }

            // Busca relacionados
            var relacionados = await _lojaService.ObterProdutosPorCategoriaAsync(produto.CategoriaId);
            relacionados = (relacionados ?? new List<ProdutoDto>())
                .Where(p => p.Id != produto.Id)
                .Take(3)
                .ToList();

            // Produto principal
            var vm = new ProdutoVM
            {
                Id = produto.Id,
                CategoriaId = produto.CategoriaId,
                CategoriaNome = produto.CategoriaNome ?? string.Empty,
                Nome = produto.Nome ?? string.Empty,
                Descricao = produto.Descricao ?? string.Empty,
                Qtde = produto.Qtde,
                ValorCusto = produto.ValorCusto,
                ValorVenda = produto.ValorVenda,
                Destaque = produto.Destaque,
                Foto = produto.Foto ?? string.Empty // 🔄 usa direto, igual HomeVM
            };

            // Relacionados
            ViewBag.Relacionados = relacionados.Select(p => new ProdutoVM
            {
                Id = p.Id,
                CategoriaId = p.CategoriaId,
                CategoriaNome = p.CategoriaNome ?? string.Empty,
                Nome = p.Nome ?? string.Empty,
                Descricao = p.Descricao ?? string.Empty,
                Qtde = p.Qtde,
                ValorCusto = p.ValorCusto,
                ValorVenda = p.ValorVenda,
                Destaque = p.Destaque,
                Foto = p.Foto ?? string.Empty
            }).ToList();

            return View(vm);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao carregar detalhes do produto {Id}", id);
            TempData["Erro"] = "Erro ao carregar produto.";
            return RedirectToAction("Produtos");
        }
    }




    public IActionResult Sobre()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [AllowAnonymous]
    // GET: /Produto/Carrinho
    public IActionResult Carrinho()
    {
        List<ProdutoDto> itensCarrinho;

        var sessionJson = HttpContext.Session.GetString("Carrinho");
        if (!string.IsNullOrEmpty(sessionJson))
        {
            try
            {
                itensCarrinho = JsonSerializer.Deserialize<List<ProdutoDto>>(sessionJson) ?? new List<ProdutoDto>();
            }
            catch
            {
                itensCarrinho = new List<ProdutoDto>();
            }
        }
        else
        {
            // fallback estático para desenvolvimento / testes
            itensCarrinho = new List<ProdutoDto>
            {
                new ProdutoDto
                {
                    Id = 1,
                    Nome = "Pão com 130 Sprites de Guloseimas 2D",
                    Descricao = "Pacote com sprites variados",
                    ValorVenda = 120.99m,
                    Foto = "/img/sprites-teste.jpg",
                    CategoriaNome = "Doces"
                }
            };
        }

        var vm = new CarrinhoVM
        {
            Itens = itensCarrinho,
            Total = itensCarrinho.Sum(x => x.ValorVenda)
        };

        return View(vm);
    }
}

