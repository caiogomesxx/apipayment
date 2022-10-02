using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces;
using Desafio.Infra.Context;

namespace Desafio.Infra.Repositories
{
    public class ListaItensRepository : GenericRepository<ListaItens>, IListaItensRepository
    {
        public ListaItensRepository(AppDbContext context) : base(context)
        {
        }
    }
}
