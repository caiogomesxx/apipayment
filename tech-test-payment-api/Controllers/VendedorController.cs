using Desafio.Data;
using Desafio.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class VendedorController : ControllerBase
    {

        private readonly AppDbContext context;
        public VendedorController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult BuscarVendedor(int id)
        {
            try 
            {
                var response = context.Vendedor.Find(id);
                return Ok(response);
            }
            catch(Exception er)
            {
                throw er;
            }
            
        }
        [HttpPost]
        public ActionResult CadastrarVendedor(Vendedor vendedor)
        {
            try 
            {
                context.Vendedor.Add(vendedor);
                context.SaveChanges();
                return Ok("Vendedor cadastrado com sucesso!");
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        [HttpDelete]
        public ActionResult RemoverVendedor(int idVendedor)
        {
            try 
            {
                var vendedor = context.Vendedor.Find(idVendedor);
                context.Vendedor.Remove(vendedor);
                context.SaveChanges();
                return Ok("Vendedor removido com sucesso!");
            }
            catch(Exception er) 
            {
                throw er; 
            }

        }
        [HttpPut]
        public ActionResult AtualizarVendedor(Vendedor vendedor)
        {
            try
            {
                var tbVendedor = context.Vendedor.Find(vendedor.IdVendedor);

                tbVendedor.CPF = vendedor.CPF;
                tbVendedor.Nome = vendedor.Nome;
                tbVendedor.Email = vendedor.Email;
                tbVendedor.Telefone = vendedor.Telefone;

                context.SaveChanges();

                return Ok("Vendedor atualizado com sucesso!");
            }
            catch(Exception er) 
            {
                throw er;
            }
        }
    }
}
