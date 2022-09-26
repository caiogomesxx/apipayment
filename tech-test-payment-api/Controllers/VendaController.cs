using Microsoft.AspNetCore.Mvc;
using Desafio.Data;
using Desafio.Models;
using Desafio.DTO;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class VendaController : ControllerBase
    {

        private readonly AppDbContext context;
        public VendaController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult BuscarVenda(int idVenda)
        {
            try
            {
                var tbVenda = context.Venda.Find(idVenda);
                var tbItens = context.ListaItens.Where(x => x.IdVenda == idVenda);
                var itens = ( from i in tbItens
                              where idVenda == i.IdVenda
                              select new
                              ListaItens()
                {
                    ValorUnitario = i.ValorUnitario,
                    IdProduto = i.IdProduto,
                    IdListaItens = i.IdListaItens,
                    IdVenda = i.IdVenda
                }).ToList();
                VendaDTO response = new VendaDTO()
                {
                    IdVenda = tbVenda.IdVenda,
                    Data = tbVenda.Data,
                    Itens = itens,
                    Status = tbVenda.Status,
                    vendedor = context.Vendedor.Find(tbVenda.IdVendedor),
                    ValorTotal = tbVenda.ValorTotal
                };
                return Ok(response);
            }
            catch (Exception er)
            {
                throw er;
            }

        }
        [HttpPost]
        public ActionResult RealizarVenda(VendaDTO venda)
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
                context.Venda.Add(tbVenda);
                context.SaveChanges();
                foreach(int item in venda.IdProduto) 
                {
                    decimal vlrUnitario = context.Produto.Find(item).ValorUnitario;
                    ListaItens tbItens = new ListaItens()
                    {
                        IdVenda = tbVenda.IdVenda,
                        IdProduto = item,
                        ValorUnitario = vlrUnitario
                    };
                    context.ListaItens.Add(tbItens);
                    vlrTotal += vlrUnitario;
                    context.SaveChanges();
                }
                Venda tbVendaAtualizada = context.Venda.Find(tbVenda.IdVenda);
                tbVendaAtualizada.ValorTotal = vlrTotal;
                context.SaveChanges();

                return Ok("Venda realizada com sucesso!");
            }
            catch (Exception er)
            {
                throw er;
            }

        }
        [HttpDelete]
        public ActionResult RemoverVenda(int idVenda)
        {
            try
            {
                var venda = context.Venda.Find(idVenda);
                context.Venda.Remove(venda);
                context.SaveChanges();
                return Ok("Venda removida com sucesso!");
            }
            catch (Exception er)
            {
                throw er;
            }

        }
        [HttpPut]
        public ActionResult AtualizarVenda(Venda venda)
        {
            try
            {
                var tbVenda = context.Venda.Find(venda.IdVenda);
                tbVenda.Status = venda.Status;
                tbVenda.IdVendedor = venda.IdVendedor;
                context.SaveChanges();
                return Ok("Venda atualizada com sucesso!");
            }
            catch (Exception er)
            {
                throw er;
            }
        }
    }
}
