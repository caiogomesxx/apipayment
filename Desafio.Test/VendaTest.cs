using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces;
using Desafio.Infra.Context;
using Desafio.Infra.DTOs;
using Desafio.Infra.Repositories;
using NSubstitute;

namespace Desafio.Test
{
    public class VendaTest
    {
        private readonly IVendaRepository _repositoryInterface = Substitute.For<IVendaRepository>();
        private readonly VendaRepository _repository;
        private readonly AppDbContext _context;
        public VendaTest()
        {
            _repository = new VendaRepository(_context);
        }

       
        [Fact]
        public async Task CadastrarVenda()
        {
            int[] produto = new int[2];
            produto[0] = 1;
            produto[1] = 2; 
            VendaDTO venda = new VendaDTO()
            {
                IdVenda = 0,
                IdVendedor = 1,
                IdProduto = produto


            };
            var response = _repositoryInterface.AddVenda(venda);

            Assert.Equal(response, 0);
        }
        [Fact]
        public async Task AtualizarVendda()
        {
            int[] produto = new int[2];
            produto[0] = 1;
            produto[1] = 2;
            VendaDTO venda = new VendaDTO()
            {
                IdVenda = 1,
                IdVendedor = 1,
                IdProduto = produto


            };
            var response = _repositoryInterface.AddVenda(venda);

            Assert.Equal(response, 0);
        }
        [Fact]
        public async Task RemoverVenda()
        {
            var response = _repositoryInterface.DeleteVenda(1);

            Assert.Equal(response, 0);
        }
    }
}