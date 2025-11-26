using Pixelix.UI.DTOs;
namespace Pixelix.UI.ViewModels
{
    public class CarrinhoVM
    {
        public List<ProdutoDto> Itens { get; set; } = new();
        public decimal Total { get; set; }
    }
}
