using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces;
using Desafio.Infra.DTOs;
using Desafio.Infra.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProdutoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        [HttpGet]
        public async Task<IActionResult> GetProduto(int id)
        {
            try 
            {
             var response = await _unitOfWork.Produtos.Get(id);
             
                if (response is null)
                    return  NotFound();
                return Ok(response);
            }
            catch (Exception er) 
            {
                throw er;
            }
        }
        [HttpPost]
        public async Task<IActionResult> CadastrarProduto(ProdutoDTO produto)
        {
            try
            {
                var product = Conversor.CastObject<Produto>(produto);
                _unitOfWork.Produtos.Add(product);        
                return Created("Produto cadastrado com sucesso",produto);
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        [HttpPut]
        public async Task<IActionResult> AtualizarProduto(ProdutoDTO produto)
        {
            try
            {
                var product = Conversor.CastObject<Produto>(produto);
                _unitOfWork.Produtos.Update(product);
                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeletarProduto(int idProduto)
        {
            try
            {
                _unitOfWork.Produtos.Delete(idProduto);
                return NoContent();
            }
            catch (Exception er)
            {
                throw er;
            }
        }
    }
}
