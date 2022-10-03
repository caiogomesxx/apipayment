using Desafio.Domain.Entities;
using Desafio.Infra.DTOs;

namespace Desafio.Domain.Interfaces
{
    public interface IVendaRepository : IGenericRepository<Venda>
    {
        int AddVenda(VendaDTO venda);
        int DeleteVenda(int idVenda);
        int AtualizarVenda(int idVenda, string status);
        VendaDTO BuscarVenda(int idVenda);
    }
}
