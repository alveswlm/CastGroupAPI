using Application.Contracts.Internal.Request;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IContaService
    {
        ValueTask<IActionResult> CriarContaAsync(ContaPostRequest contaPostRequest);

        ValueTask<IActionResult> BuscarContaAsync(ContaGetRequest contaGetRequest);

        ValueTask<IActionResult> ListarContasAsync();

        ValueTask<IActionResult> AtualizarContaAsync(ContaPutRequest contaPutRequest);

        ValueTask<IActionResult> ExcluirContaAsync(string nome);
    }
}