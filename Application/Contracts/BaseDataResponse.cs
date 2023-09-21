using Newtonsoft.Json;

namespace Application.Contracts
{
    public class BaseDataResponse
    {
        public BaseDataResponse(int status, string mensagem)
        {
            Status = status;
            Mensagem = mensagem;
        }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }
    }
}