using Application.Contracts.Internal.Request;
using Application.Interfaces;
using Infra.Data.Context;
using Infra.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services
{
    public class ContaService : IContaService
    {
        private readonly ContaDbContext _dbContext;

        public ContaService(ContaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<IActionResult> CriarContaAsync(ContaPostRequest criarContaPostRequest)
        {
            var conta = new ContaEntity
            {
                Nome = criarContaPostRequest.Nome,
                Descricao = criarContaPostRequest.Descricao
            };

            _dbContext.Add(conta);
            await _dbContext.SaveChangesAsync();

            return (IActionResult)conta;
        }
    }
}