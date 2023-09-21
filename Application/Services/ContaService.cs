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

            return new ResultObject(HttpStatusCode.OK, $"Conta {conta.Nome} criada com sucesso.");
        }

        public async ValueTask<IActionResult> BuscarContaAsync(ContaGetRequest contaGetRequest)
        {
            var conta = await _dbContext.Contas.FindAsync(contaGetRequest.Nome);

            return new ResultObject(HttpStatusCode.OK, conta);
        }

        public async ValueTask<IActionResult> ListarContasAsync()
        {
            var conta = _dbContext.Contas;

            return new ResultObject(HttpStatusCode.OK, conta);
        }

        public async ValueTask<IActionResult> AtualizarContaAsync(ContaPutRequest contaPutRequest)
        {
            var conta = new ContaEntity(contaPutRequest.Nome, contaPutRequest.Descricao);

            _dbContext.Update(conta);
            await _dbContext.SaveChangesAsync();

            return new ResultObject(HttpStatusCode.OK, $"Descrição da conta {conta.Nome} atualizada com sucesso.");
        }

        public async ValueTask<IActionResult> ExcluirContaAsync(string nome)
        {
            var conta = new ContaEntity(nome);

            _dbContext.Remove(conta);
            await _dbContext.SaveChangesAsync();

            return new ResultObject(HttpStatusCode.OK, $"Conta {conta.Nome} excluída com sucesso.");
        }
    }
}