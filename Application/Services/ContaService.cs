using Application.Contracts.Internal.Request;
using Application.Interfaces;
using Infra.CrossCutting.Response;
using Infra.Data.Context;
using Infra.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.Services
{
    public class ContaService : IContaService
    {
        private readonly ContaDbContext _dbContext;

        public ContaService(ContaDbContext dbContext) =>
            _dbContext = dbContext;

        public async ValueTask<IActionResult> CriarContaAsync(ContaPostRequest contaPostRequest)
        {
            var conta = new ContaEntity(contaPostRequest.Nome, contaPostRequest.Descricao);

            _dbContext.Add(conta);
            await _dbContext.SaveChangesAsync();

            return new ResultObject(HttpStatusCode.OK, $"Conta: {conta.Nome} criada com sucesso.");
        }

        public async ValueTask<IActionResult> BuscarContaAsync(ContaGetRequest contaGetRequest)
        {
            var conta = await _dbContext.Contas.Where(c => c.Nome == contaGetRequest.Nome).FirstOrDefaultAsync();

            return new ResultObject(HttpStatusCode.OK, conta);
        }
    }
}