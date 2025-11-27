using System.Text.Json.Serialization;

namespace Pixelix.UI.DTOs;

public class CategoriaDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("nome")]
    public string Nome { get; set; }

    [JsonPropertyName("foto")]
    public string? Foto { get; set; }   // <<< PRECISA SER NULLABLE!

    [JsonPropertyName("cor")]
    public string? Cor { get; set; }    // <<< TAMBÉM NULLABLE
}
