using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pixelix.API.Data;
using Pixelix.API.Models;
using Pixelix.API.Services.Interfaces;
using Pixelix.API.DTOs;

namespace Pixelix.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IFileService _fileService;

    public ProdutosController(AppDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    // GET: api/Produtos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<produtoDtos>>> GetProdutos()
    {
        var produtos = await _context.Produtos
            .Include(p => p.Categoria)
            .ToListAsync();

        var produtosDto = produtos.Select(p => MapToDto(p)).ToList();
        return Ok(produtosDto);
    }

    // GET: api/Produtos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<produtoDtos>> GetProduto(int id)
    {
        var produto = await _context.Produtos
            .Include(p => p.Categoria)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (produto == null)
        {
            return NotFound();
        }

        return Ok(MapToDto(produto));
    }

    // GET: api/Produtos/categoria/5
    [HttpGet("categoria/{categoriaId}")]
    public async Task<ActionResult<IEnumerable<produtoDtos>>> GetProdutosPorCategoria(int categoriaId)
    {
        var produtos = await _context.Produtos
            .Include(p => p.Categoria)
            .Where(p => p.CategoriaId == categoriaId)
            .ToListAsync();

        var produtosDto = produtos.Select(p => MapToDto(p)).ToList();
        return Ok(produtosDto);
    }

    // GET: api/Produtos/destaque
    [HttpGet("destaque")]
    public async Task<ActionResult<IEnumerable<produtoDtos>>> GetProdutosDestaque()
    {
        var produtos = await _context.Produtos
            .Include(p => p.Categoria)
            .Where(p => p.Destaque)
            .ToListAsync();

        var produtosDto = produtos.Select(p => MapToDto(p)).ToList();
        return Ok(produtosDto);
    }

    // PUT: api/Produtos/5
    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> PutProduto(int id, [FromForm] ProdutoUpdateDto produtoDtos)
    {
        if (id != produtoDtos.Id)
        {
            return BadRequest();
        }

        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
        {
            return NotFound();
        }

        // Atualizar propriedades
        produto.CategoriaId = produtoDtos.CategoriaId;
        produto.Nome = produtoDtos.Nome;
        produto.Descricao = produtoDtos.Descricao;
        produto.Qtde = produtoDtos.Qtde;
        produto.ValorCusto = produtoDtos.ValorCusto;
        produto.ValorVenda = produtoDtos.ValorVenda;
        produto.Destaque = produtoDtos.Destaque;

        // Processar nova foto se fornecida
        if (produtoDtos.Foto != null && produtoDtos.Foto.Length > 0)
        {
            // Deletar foto antiga se existir
            if (!string.IsNullOrEmpty(produto.Foto))
            {
                await _fileService.DeleteFileAsync(produto.Foto);
            }

            // Salvar nova foto
            produto.Foto = await _fileService.SaveFileAsync(produtoDtos.Foto, "img\\produtos");
        }

        _context.Entry(produto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProdutoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return Ok(MapToDto(produto));
    }

    // POST: api/Produtos
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult<produtoDtos>> PostProduto([FromForm] ProdutoCreateDto produtoDtos)
    {
        var produto = new Produto
        {
            CategoriaId = produtoDtos.CategoriaId,
            Nome = produtoDtos.Nome,
            Descricao = produtoDtos.Descricao,
            Qtde = produtoDtos.Qtde,
            ValorCusto = produtoDtos.ValorCusto,
            ValorVenda = produtoDtos.ValorVenda,
            Destaque = produtoDtos.Destaque
        };

        // Salvar foto se fornecida
        if (produtoDtos.Foto != null && produtoDtos.Foto.Length > 0)
        {
            produto.Foto = await _fileService.SaveFileAsync(produtoDtos.Foto, "img\\produtos");
        }

        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        // Carregar categoria para incluir no DTO
        await _context.Entry(produto)
            .Reference(p => p.Categoria)
            .LoadAsync();

        return CreatedAtAction("GetProduto", new { id = produto.Id }, MapToDto(produto));
    }

    // DELETE: api/Produtos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null)
        {
            return NotFound();
        }

        // Deletar foto associada se existir
        if (!string.IsNullOrEmpty(produto.Foto))
        {
            await _fileService.DeleteFileAsync(produto.Foto);
        }

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProdutoExists(int id)
    {
        return _context.Produtos.Any(e => e.Id == id);
    }

    private produtoDtos MapToDto(Produto produto)
    {
        return new produtoDtos
        {
            Id = produto.Id,
            CategoriaId = produto.CategoriaId,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Qtde = produto.Qtde,
            ValorCusto = produto.ValorCusto,
            ValorVenda = produto.ValorVenda,
            Destaque = produto.Destaque,
            Foto = !string.IsNullOrEmpty(produto.Foto) ? _fileService.GetFileUrl(produto.Foto) : null,
            CategoriaNome = produto.Categoria?.Nome
        };
    }
}

