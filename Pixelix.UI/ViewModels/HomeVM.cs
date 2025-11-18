using Pixelix.UI.DTOs;

namespace Pixelix.UI.ViewModels;

public class HomeVM
{
    public List<CategoriaDto> Categorias { get; set; } = new();
    public List<ProdutoDto> ProdutosDestaque { get; set; } = new();
}
