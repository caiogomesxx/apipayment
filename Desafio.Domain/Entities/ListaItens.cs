using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.Domain.Entities
{
    public class ListaItens
    {
        [Key]
        public int IdListaItens { get; set; }
        public decimal ValorUnitario { get; set; }
        [Required]
        [ForeignKey("IdProduto")]
        public int IdProduto { get; set; }
        [Required]
        [ForeignKey("IdVenda")]
        public int IdVenda { get; set; }
    }
}
