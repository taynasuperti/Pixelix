using Pixelix.UI.DTOs;
namespace Pixelix.UI.ViewModels
{
public class SpritesPageVM
{
    public List<CategoriaDto> Categorias { get; set; } = new();
    public List<ProdutoDto> Produtos { get; set; } = new();
}

}