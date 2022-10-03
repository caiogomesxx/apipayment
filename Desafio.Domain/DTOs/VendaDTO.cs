namespace Desafio.Infra.DTOs
{
    public class VendaDTO
    {
        public int IdVenda { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public int IdVendedor { get; set; }
        public Decimal ValorTotal { get; set; }
        public List<ListaItensDTO>? ListaItens { get; set; }
        public List<ProdutoDTO> Produto { get; set; }
        public VendedorDTO Vendedor { get; set; }
        public int[]? IdProduto { get; set; }

    }
}
