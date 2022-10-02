using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces;
using Desafio.Infra.Context;

namespace Desafio.Infra.Repositories
{
    public class VendedorRepository : GenericRepository<Vendedor>, IVendedorRepository
    {

        public VendedorRepository(AppDbContext context) : base(context)
        {
        }

    }
}
