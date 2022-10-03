using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces;
using Desafio.Infra.Context;
using Desafio.Infra.DTOs;
using Desafio.Infra.Repositories;
using NSubstitute;

namespace Desafio.Test
{
    public class VendedorTest
    {
        private readonly IVendedorRepository _repositoryInterface = Substitute.For<IVendedorRepository>();
        private readonly VendedorRepository _repository;
        private readonly AppDbContext _context;
        
        public VendedorTest()
        {
            _repository = new VendedorRepository(_context);
        }

        [Fact]
        public async Task GetVendedor()
        {

            var response = _repositoryInterface.Get(1);

            Assert.NotNull(response);
        }
        [Fact]
        public async Task CadastrarVendedor()
        {
            Vendedor vendedor = new Vendedor()
            {
                IdVendedor = 0,
                CPF = "11111111",
                Nome = "teste",
                Email = "teste@teste.com",
                Telefone = "999999999"

            };
            var response = _repositoryInterface.Add(vendedor);

            Assert.Equal(response,0);
        }
        [Fact]
        public async Task AtualizarVendedor()
        {
            Vendedor vendedor = new Vendedor()
            {
                IdVendedor = 1,
                CPF = "11111111",
                Nome = "teste",
                Email = "teste@teste.com",
                Telefone = "999999999"

            };
            var response = _repositoryInterface.Update(vendedor);

            Assert.Equal(response, 0);
        }
        [Fact]
        public async Task RemoverVendedor()
        {
            var response = _repositoryInterface.Delete(1);

            Assert.Equal(response, 0);
        }
    }
}