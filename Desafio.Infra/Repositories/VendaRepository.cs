using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces;
using Desafio.Infra.Context;
using Desafio.Infra.DTOs;
using Desafio.Infra.Utils;

namespace Desafio.Infra.Repositories
{
    public class VendaRepository : GenericRepository<Venda>, IVendaRepository
    {

        public VendaRepository(AppDbContext context) : base(context)
        {
        }

        public int AddVenda(VendaDTO venda)
        {
            try
            {
                decimal vlrTotal = 0;
                Venda tbVenda = new Venda()
                {
                    Data = DateTime.Now,
                    Status = "Aguardando pagamento",
                    IdVendedor = venda.IdVendedor
                };
                _context.Venda.Add(tbVenda);
                _context.SaveChanges();

                foreach (int item in venda.IdProduto)
                {
                    ListaItensRepository listaItensModel = new ListaItensRepository(_context);

                    decimal vlrUnitario = _context.Produto.Find(item).ValorUnitario;
                    ListaItens tbItens = new ListaItens()
                    {
                        IdVenda = tbVenda.IdVenda,
                        IdProduto = item,
                        ValorUnitario = vlrUnitario
                    };
                    listaItensModel.Add(tbItens);
                    vlrTotal += vlrUnitario;
                    _context.SaveChanges();
                }

                Venda tbVendaAtualizada = _context.Venda.Find(tbVenda.IdVenda);
                tbVendaAtualizada.ValorTotal = vlrTotal;
                _context.SaveChanges();
                return 0;
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        public int DeleteVenda(int idVenda)
        {
            try
            {
                var venda = _context.Venda.Find(idVenda);
                _context.Venda.Remove(venda);
                var lstItens = _context.ListaItens.Where(x => x.IdVenda == idVenda).ToList();
                foreach (var item in lstItens)
                {
                    _context.ListaItens.Remove(item);
                }
                return 0;
                _context.SaveChanges();

            }
            catch (Exception er)
            {
                throw er;
            }
        }

        public int AtualizarVenda(int idVenda, string status)
        {
            try
            {
                var tbVenda = _context.Venda.Find(idVenda);

                switch (tbVenda.Status)
                {
                    case "Aguardando pagamento":
                        if (status == "Pagamento Aprovado" || status == "Cancelada")
                            tbVenda.Status = status;
                        else
                            throw new Exception("Informe um status valido!");
                        break;

                    case "Pagamento Aprovado":
                        if (status == "Enviado para Transportadora" || status == "Cancelada")
                            tbVenda.Status = status;
                        else
                            throw new Exception("Informe um status valido!");
                        break;

                    case "Enviado para Transportadora":
                        if (status == "Entregue")
                            tbVenda.Status = status;
                        else
                            throw new Exception("Informe um status valido!");
                        break;

                    case "Entregue":
                    case "Cancelada":
                        throw new Exception("Não é possível atualizar o status da venda se ela já foi entregue ou cancelada.");
                        break;

                    default:
                        throw new Exception("Informe um status valido.");
                        break;

                }
                _context.SaveChanges();
                return 0;
            }
            catch (Exception er)
            {
                throw er;
            }
        }

        public VendaDTO BuscarVenda(int idVenda)
        {
            try
            {
                VendaDTO response = null;
                var tbVenda = _context.Venda.Find(idVenda);
                if(tbVenda is not null)
                {
                var tbItens = _context.ListaItens.Where(x => x.IdVenda == idVenda).ToList();
                ProdutoDTO produto = new ProdutoDTO();
                response = new VendaDTO();
                response.IdVenda = tbVenda.IdVenda;
                response.Data = tbVenda.Data;
                response.Status = tbVenda.Status;
                
                response.IdVendedor = tbVenda.IdVendedor;
                List<ProdutoDTO> lstProdutos = new List<ProdutoDTO>();
                
                foreach (var item in tbItens) 
                {
                    produto = Conversor.CastObject<ProdutoDTO>(_context.Produto.Find(item.IdProduto));
                    lstProdutos.Add(produto);

                    response.ValorTotal += produto.ValorUnitario;
                }

                response.Produto = lstProdutos;
                var vendedor = _context.Vendedor.Find(response.IdVendedor);
                if(vendedor != null)
                response.Vendedor = Conversor.CastObject<VendedorDTO>(vendedor);
                }
                
                return response;
            }
            catch (Exception er)
            {
                throw er;
            }

        }
    }
}