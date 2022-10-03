using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces;
using Desafio.Infra.Context;
using Desafio.Infra.DTOs;
using Desafio.Infra.Repositories;
using NSubstitute;

namespace Desafio.Test
{
    public class ProdutoTest
    {
        private readonly IProdutoRepository _repositoryInterface = Substitute.For<IProdutoRepository>();
        private readonly ProdutoRepository _repository;
        private readonly AppDbContext _context;
        public ProdutoTest()
        {
            _repository = new ProdutoRepository(_context);
        }

        [Fact]
        public async Task GetProduto()
        {

            var response = _repositoryInterface.Get(1);

            Assert.NotNull(response);
        }
        [Fact]
        public async Task CadastrarProduto()
        {
            Produto produto = new Produto()
            {
                IdProduto = 55,
                Nome = "teste",
               


            };
            var response = _repositoryInterface.Add(produto);

            Assert.Equal(response, 0);
        }
        [Fact]
        public async Task AtualizarProduto()
        {
            Produto produto = new Produto()
            {
                IdProduto = 1,
                Nome = "teste",
                ValorUnitario = 3.11m


            };
            var response = _repositoryInterface.Update(produto);

            Assert.Equal(response, 0);
        }
        [Fact]
        public async Task RemoverProduto()
        {
            var response = _repositoryInterface.Delete(1);

            Assert.Equal(response, 0);
        }
    }
}