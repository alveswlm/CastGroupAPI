using Application.Contracts.Internal.Request;
using Microsoft.AspNetCore.Mvc;

namespace Application.Interfaces
{
    public interface IContaService
    {
        ValueTask<IActionResult> CriarContaAsync(ContaPostRequest contaPostRequest);

        ValueTask<IActionResult> BuscarContaAsync(ContaGetRequest contaGetRequest);
    }
}