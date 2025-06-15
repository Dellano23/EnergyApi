namespace Fiap.Api.Energy.Services
{
    public interface IPedidoService
    {
        IEnumerable<PedidoModel> ObterTodosPedidos();
        IEnumerable<PedidoModel> ObterTodosPedidosComDetalhes();
        PedidoModel ObterPedidoPorId(int id);
        PedidoModel ObterPedidoPorIdComDetalhes(int id);
        void AdicionarPedido(PedidoModel pedido);
        void AtualizarPedido(PedidoModel pedido);
        void DeletarPedido(PedidoModel pedido);
    }
}
