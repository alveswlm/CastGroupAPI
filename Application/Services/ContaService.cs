using Application.Contracts.Internal.Request;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services
{
    public class ContaService : IContaService
    {
        public async ValueTask<IActionResult> CriarContaAsync(ContaPostRequest criarContaPostRequest)
        {
            return null;
        }
    }
}