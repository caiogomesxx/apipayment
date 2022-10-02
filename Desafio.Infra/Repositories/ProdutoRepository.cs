using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces;
using Desafio.Infra.Context;

namespace Desafio.Infra.Repositories
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
