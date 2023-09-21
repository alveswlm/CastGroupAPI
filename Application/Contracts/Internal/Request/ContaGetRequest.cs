using System.Text.Json.Serialization;

namespace Application.Contracts.Internal.Request
{
    public class ContaGetRequest
    {
        [JsonPropertyName("nome")]
        public string Nome { get; set; }
    }
}