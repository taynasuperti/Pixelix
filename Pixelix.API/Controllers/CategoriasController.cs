using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pixelix.API.Data;
using Pixelix.API.DTOs;
using Pixelix.API.Models;
using Pixelix.API.Services.Interfaces;
using Microsoft.AspNetCore.Http;


namespace Pixelix.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IFileService _fileService;

    public CategoriasController(AppDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    // GET: api/Categorias
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
    {
        var categorias = await _context.Categorias.ToListAsync();
        
        // Converter caminhos relativos em URLs completas
        foreach (var categoria in categorias)
        {
            if (!string.IsNullOrEmpty(categoria.Foto))
            {
                categoria.Foto = _fileService.GetFileUrl(categoria.Foto);
            }
        }
        
        return categorias;
    }

    // GET: api/Categorias/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Categoria>> GetCategoria(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);

        if (categoria == null)
        {
            return NotFound();
        }

        // Converter caminho relativo em URL completa
        if (!string.IsNullOrEmpty(categoria.Foto))
        {
            categoria.Foto = _fileService.GetFileUrl(categoria.Foto);
        }

        return categoria;
    }

    // PUT: api/Categorias/5
    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
public async Task<IActionResult> PutCategoria(int id, [FromForm] CategoriaDto categoriaDto)
{
    if (id != categoriaDto.Id)
        return BadRequest("ID da URL não corresponde ao ID enviado.");

    var categoria = await _context.Categorias.FindAsync(id);
    if (categoria == null)
        return NotFound();

    categoria.Nome = categoriaDto.Nome;
    categoria.Cor = categoriaDto.Cor;

    if (categoriaDto.FotoUpload != null && categoriaDto.FotoUpload.Length > 0)
    {
        if (!string.IsNullOrEmpty(categoria.Foto))
            await _fileService.DeleteFileAsync(categoria.Foto);

        categoria.Foto = await _fileService.SaveFileAsync(categoriaDto.FotoUpload, "img/categorias");
    }

    await _context.SaveChangesAsync();

    categoriaDto.FotoUrl = !string.IsNullOrEmpty(categoria.Foto)
        ? _fileService.GetFileUrl(categoria.Foto)
        : null;

    return Ok(categoriaDto);
}


    // POST: api/Categorias
[HttpPost]
[Consumes("multipart/form-data")]
public async Task<ActionResult<Categoria>> PostCategoria([FromForm] CategoriaDto categoriaDto)
{
    var categoria = new Categoria
    {
        Nome = categoriaDto.Nome,
        Cor = categoriaDto.Cor
    };

    if (categoriaDto.FotoUpload != null && categoriaDto.FotoUpload.Length > 0)
    {
        categoria.Foto = await _fileService.SaveFileAsync(categoriaDto.FotoUpload, "img/categorias");
    }

    _context.Categorias.Add(categoria);
    await _context.SaveChangesAsync();

    categoriaDto.Id = categoria.Id;
    categoriaDto.FotoUrl = !string.IsNullOrEmpty(categoria.Foto)
        ? _fileService.GetFileUrl(categoria.Foto)
        : null;

    return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoriaDto);
}


    // DELETE: api/Categorias/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoria(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null)
        {
            return NotFound();
        }

        // Deletar foto associada se existir
        if (!string.IsNullOrEmpty(categoria.Foto))
        {
            await _fileService.DeleteFileAsync(categoria.Foto);
        }

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CategoriaExists(int id)
    {
        return _context.Categorias.Any(e => e.Id == id);
    }
}
