using Pixelix.UI.DTOs;
using Pixelix.UI.Models;
using Pixelix.UI.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Pixelix.UI.Services.Implementations;

public class LojaService : BaseApiService, ILojaService
{
    public LojaService(
        HttpClient httpClient,
        IOptions<ApiSettings> apiSettings,
        IHttpContextAccessor httpContextAccessor)
        : base(httpClient, apiSettings, httpContextAccessor)
    {
    }

    public async Task<List<CategoriaDto>> ObterCategoriasAtivasAsync()
{
    return await GetAsync<List<CategoriaDto>>("api/categorias");
}

public async Task<List<ProdutoDto>> ObterProdutosDestaqueAsync()
{
    return await GetAsync<List<ProdutoDto>>("api/produtos/destaque");
}

public async Task<List<ProdutoDto>> ObterTodosProdutosAsync()
{
    return await GetAsync<List<ProdutoDto>>("api/produtos");
}

public async Task<List<ProdutoDto>> ObterProdutosPorCategoriaAsync(int categoriaId)
{
    return await GetAsync<List<ProdutoDto>>($"api/produtos/categoria/{categoriaId}");
}

public async Task<ProdutoDto> ObterProdutoPorIdAsync(int id)
{
    return await GetAsync<ProdutoDto>($"api/produtos/{id}");
}

}