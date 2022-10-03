using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces;
using Desafio.Infra.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public VendaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    
        [HttpGet]
        public IActionResult GetVenda(int id)
        {
            try
            {
                var response = _unitOfWork.Vendas.BuscarVenda(id);
                if (response is null)
                    return NotFound();

                return Ok(response);
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        [HttpPost]
        public IActionResult RealizarVenda(VendaDTO venda)
        {
            try 
            {
                
            _unitOfWork.Vendas.AddVenda(venda);
             return Created("Venda Realizada com sucesso!",venda);
            }
            catch (Exception er) 
            {
                throw er;
            }
        }
        [HttpPut]
        public IActionResult AtualizarVenda(int idVenda, string status)
        {
            try
            {
                _unitOfWork.Vendas.AtualizarVenda(idVenda,status);
                return Ok("Venda atualizada com sucesso!");
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        [HttpDelete]
        public IActionResult DeleteVenda(int idVenda)
        {
            try
            {
                _unitOfWork.Vendas.DeleteVenda(idVenda);
                return NoContent();
            }
            catch (Exception er)
            {
                throw er;
            }
        }
    }
}
