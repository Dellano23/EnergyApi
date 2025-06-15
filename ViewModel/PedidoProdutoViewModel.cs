namespace Fiap.Api.Energy.ViewModel
{
    public class PedidoProdutoViewModel
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoViewModel Produto { get; set; }
    }
}
