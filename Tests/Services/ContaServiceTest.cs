using Application.Contracts.Internal.Request;
using Application.Interfaces;
using Application.Services;
using Infra.Data.Context;
using Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Tests.Services
{
    [TestClass]
    public class ContaServiceTest
    {
        private IContaService _contaService;

        [TestMethod]
        public async Task CriarContaAsync_ContaCriada_Sucesso()
        {
            //Arrange
            var contaPostRequest = new ContaPostRequest()
            {
                Nome = "C0",
                Descricao = "Conta C0"
            };

            var mockDbSet = new Mock<DbSet<ContaEntity>>();

            var mockContext = new Mock<ContaDbContext>();
            mockContext.Setup(x => x.Contas).Returns(mockDbSet.Object);

            _contaService = new ContaService(mockContext.Object);

            //Act
            var result = await _contaService.CriarContaAsync(contaPostRequest);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task BuscarContaAsync_ContaEncontrada_Sucesso()
        {
            //Arrange
            var contaGetRequest = new ContaGetRequest()
            {
                Nome = "C0"
            };

            var conta = new ContaEntity()
            {
                Nome = "C0"
            };

            var mockDbSet = new Mock<DbSet<ContaEntity>>();
            mockDbSet.Setup(x => x.FindAsync(It.IsAny<ContaEntity>())).ReturnsAsync(conta);

            var mockContext = new Mock<ContaDbContext>();
            mockContext.Setup(x => x.Contas).Returns(mockDbSet.Object);

            _contaService = new ContaService(mockContext.Object);

            //Act
            var result = await _contaService.BuscarContaAsync(contaGetRequest);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task AtualizarContaAsync_ContaAtualizada_Sucesso()
        {
            //Arrange
            var contaPutRequest = new ContaPutRequest()
            {
                Nome = "C2",
                Descricao = "Segunda conta criada (teste)"
            };

            var mockDbSet = new Mock<DbSet<ContaEntity>>();

            var mockContext = new Mock<ContaDbContext>();
            mockContext.Setup(x => x.Contas).Returns(mockDbSet.Object);

            _contaService = new ContaService(mockContext.Object);

            //Act
            var result = await _contaService.AtualizarContaAsync(contaPutRequest);

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task ExcluirContaAsync_ContaExcluida_Sucesso()
        {
            //Arrange
            var nome = "C2";

            var mockDbSet = new Mock<DbSet<ContaEntity>>();

            var mockContext = new Mock<ContaDbContext>();
            mockContext.Setup(x => x.Contas).Returns(mockDbSet.Object);

            _contaService = new ContaService(mockContext.Object);

            //Act
            var result = await _contaService.ExcluirContaAsync(nome);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}