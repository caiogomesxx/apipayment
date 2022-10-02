using Desafio.Domain.Interfaces;
using Desafio.Infra.Context;

namespace Desafio.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IListaItensRepository ListaItens { get; }
        public IProdutoRepository Produtos { get; }
        public IVendaRepository Vendas { get; }
        public IVendedorRepository Vendedor { get; }

        public UnitOfWork(AppDbContext context, IListaItensRepository listaItens,
            IProdutoRepository produtos,IVendaRepository vendas, IVendedorRepository vendedor)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            ListaItens = listaItens ?? throw new ArgumentNullException(nameof(listaItens));
            Produtos = produtos ?? throw new ArgumentNullException(nameof(produtos));
            Vendas = vendas ?? throw new ArgumentNullException(nameof(vendas));
            Vendedor = vendedor ?? throw new ArgumentNullException(nameof(vendedor));
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
