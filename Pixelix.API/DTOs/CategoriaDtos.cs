using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Pixelix.API.DTOs;

public class CategoriaDto
{
    public int Id { get; set; }  // usado no PUT, ignorado no POST

    [Required]
    [StringLength(50)]
    public string Nome { get; set; } = string.Empty;

    // opcional (você pode tirar se não usar)
    [StringLength(26)]
    public string Cor { get; set; }

    // arquivo enviado no POST/PUT
    public IFormFile FotoUpload { get; set; }

    // caminho final (retornado no GET)
    public string FotoUrl { get; set; }
}
