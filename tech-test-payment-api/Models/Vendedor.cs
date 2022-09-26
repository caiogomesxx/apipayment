using System.ComponentModel.DataAnnotations;

namespace Desafio.Models
{
    public class Vendedor
    {
        [Key]
        public int IdVendedor { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
