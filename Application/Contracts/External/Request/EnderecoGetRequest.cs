using Newtonsoft.Json;

namespace Application.Contracts.External.Request
{
    public class EnderecoGetRequest
    {
        [JsonProperty("cep")]
        public string Cep { get; set; }
    }
}