using Application.Contracts.External.Request;
using Application.Contracts.External.Response;
using Application.Interfaces;
using RestSharp;

namespace Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        public async ValueTask<EnderecoGetResponse> BuscaEnderecoAsync(EnderecoGetRequest buscaEnderecoGetRequest)
        {
            var client = new RestClient("http://viacep.com.br/ws/{cep}/json/");

            var request = new RestRequest("ws/{cep}/json", Method.Get);
            request.AddUrlSegment("cep", buscaEnderecoGetRequest.Cep);

            var response = await client.GetAsync<EnderecoGetResponse>(request) ?? throw new ArgumentException("Ocorreu um erro ao buscar o endereço");

            return response;
        }
    }
}