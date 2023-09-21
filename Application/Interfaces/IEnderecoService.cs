using Application.Contracts.External.Endereco.Request;
using Application.Contracts.External.Endereco.Response;

namespace Application.Interfaces
{
    public interface IEnderecoService
    {
        ValueTask<EnderecoGetResponse> BuscaEnderecoAsync(EnderecoGetRequest buscaEnderecoGetRequest);
    }
}