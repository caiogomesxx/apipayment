using Desafio.Models;

namespace Desafio.DTO
{
    public class VendaDTO
    {
        public int IdVenda { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public int IdVendedor { get; set; }
        public int IdListaItens { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorUnitario { get; set; }
        public int[] IdProduto { get; set; }

        public List<ListaItens>? Itens { get; set; }
        public Vendedor? vendedor { get; set; }
    }
}
