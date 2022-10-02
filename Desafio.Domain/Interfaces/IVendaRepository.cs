using Desafio.Domain.Entities;
using Desafio.Infra.DTOs;

namespace Desafio.Domain.Interfaces
{
    public interface IVendaRepository : IGenericRepository<Venda>
    {
        void AddVenda(VendaDTO venda);
        void DeleteVenda(int idVenda);
        void AtualizarVenda(int idVenda, string status);
        VendaDTO BuscarVenda(int idVenda);
    }
}
