using Application.Contracts.Internal.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CastGroupAPI.Controllers
{
    [Route("api/conta")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContaController(IContaService contaService) =>
            _contaService = contaService;

        [HttpPost]
        public async ValueTask<IActionResult> CriarContaAsync([FromBody] ContaPostRequest contaPostRequest)
        {
            return await _contaService.CriarContaAsync(contaPostRequest);
        }

        [HttpGet("{nome}")]
        public async ValueTask<IActionResult> BuscarContaAsync([FromQuery] ContaGetRequest contaGetRequest)
        {
            return await _contaService.BuscarContaAsync(contaGetRequest);
        }

        [HttpGet]
        public async ValueTask<IActionResult> ListarContasAsync()
        {
            return await _contaService.ListarContasAsync();
        }

        [HttpPut]
        public async ValueTask<IActionResult> AtualizarContaAsync([FromBody] ContaPutRequest contaPutRequest)
        {
            return await _contaService.AtualizarContaAsync(contaPutRequest);
        }

        [HttpDelete("{nome}")]
        public async ValueTask<IActionResult> ExcluirContaAsync(string nome)
        {
            return await _contaService.ExcluirContaAsync(nome);
        }
    }
}