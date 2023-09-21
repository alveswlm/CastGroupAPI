using Newtonsoft.Json;

namespace Application.Contracts.External.Endereco.Request
{
    public class EnderecoGetRequest
    {
        [JsonProperty("cep")]
        public string Cep { get; set; }
    }
}