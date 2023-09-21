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

        [HttpGet]
        public async ValueTask<IActionResult> BuscarContaAsync([FromQuery] ContaGetRequest contaGetRequest)
        {
            return await _contaService.BuscarContaAsync(contaGetRequest);
        }
    }
}