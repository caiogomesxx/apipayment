using Desafio.Data;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class ProdutoController : ControllerBase
    {

        private readonly AppDbContext context;
        public ProdutoController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult BuscarProduto(int id)
        {
            try 
            {
                var response = context.Produto.Find(id);
                return Ok(response);
            }
            catch(Exception er)
            {
                throw er;
            }
        }
        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {
            try 
            {
                context.Produto.Add(produto);
                context.SaveChanges();
                return Ok("Produto cadastrado com sucesso!");
            }
            catch(Exception er) 
            {
                throw er;
            }
            
        }
        [HttpDelete]
        public ActionResult RemoverProduto(int idProduto)
        {
            try 
            {
                var produto = context.Produto.Find(idProduto);
                context.Produto.Remove(produto);
                context.SaveChanges();
                return Ok("Produto removido com sucesso!");
            }
            catch(Exception er) 
            {
                throw er;
            }
        }
        [HttpPut]
        public ActionResult AtualizarProduto(Produto produto)
        {
            try 
            {
                var tbProduto = context.Produto.Find(produto.IdProduto);

                tbProduto.Nome = produto.Nome;
                tbProduto.ValorUnitario = produto.ValorUnitario;

                context.SaveChanges();

                return Ok("Produto atualizado com sucesso!");
            }
            catch(Exception er) 
            {
                throw er;
            }
        }
    }
}
