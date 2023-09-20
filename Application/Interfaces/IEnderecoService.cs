using Application.Contracts.External.Request;
using Application.Contracts.External.Response;

namespace Application.Interfaces
{
    public interface IEnderecoService
    {
        ValueTask<EnderecoGetResponse> BuscaEnderecoAsync(EnderecoGetRequest buscaEnderecoGetRequest);
    }
}