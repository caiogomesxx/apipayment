namespace Desafio.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IListaItensRepository ListaItens { get; }
        IProdutoRepository Produtos { get; }
        IVendaRepository Vendas { get; }
        IVendedorRepository Vendedor { get; }

        int Commit();
    }
 }
