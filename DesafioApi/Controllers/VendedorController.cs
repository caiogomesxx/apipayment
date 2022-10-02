using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces;
using Desafio.Infra.DTOs;
using Desafio.Infra.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DesafioApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public VendedorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        [HttpGet]
        public IActionResult GetVendedor(int id)
        {
            try
            {
                var response = _unitOfWork.Vendedor.Get(id);
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
        public IActionResult CadastrarVendedor(VendedorDTO vendedor)
        {
            try
            {
                var vend = Conversor.CastObject<Vendedor>(vendedor); 
                _unitOfWork.Vendedor.Add(vend);
                return Created("Vendedor Cadastrado com sucesso!",vendedor);
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        [HttpPut]
        public IActionResult AtualizarDadosVendedor(VendedorDTO vendedor)
        {
            try
            {
                var vend = Conversor.CastObject<Vendedor>(vendedor);
                _unitOfWork.Vendedor.Update(vend);
                return Ok("Vendedor atualizado com sucesso!");
            }
            catch (Exception er)
            {
                throw er;
            }
        }
        [HttpDelete]
        public IActionResult RemoverVendedor(int idVendedor)
        {
            try
            {
                _unitOfWork.Vendedor.Delete(idVendedor);
                return NoContent();
            }
            catch (Exception er)
            {
                throw er;
            }
        }
    }
}
