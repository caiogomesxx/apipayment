using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.Domain.Entities
{
    public class Venda
    {
        [Key]
        public int IdVenda { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        [Required]
        [ForeignKey("IdVendedor")]
        public int IdVendedor { get; set; }
        public Decimal ValorTotal { get; set; }
    }
}
