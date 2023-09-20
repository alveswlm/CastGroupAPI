using Application.Contracts.External.Endereco.Request;
using Application.Contracts.External.Endereco.Response;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CastGroupAPI.Controllers
{
    [Route("api/endereco")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService) =>
            _enderecoService = enderecoService;

        [HttpGet("busca")]
        public async ValueTask<EnderecoGetResponse> BuscaEnderecoAsync([FromQuery] EnderecoGetRequest buscaEnderecoGetRequest)
        {
            return await _enderecoService.BuscaEnderecoAsync(buscaEnderecoGetRequest);
        }
    }
}