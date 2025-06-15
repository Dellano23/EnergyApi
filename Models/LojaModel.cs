using Fiap.Api.Energy.Models;

namespace Fiap.Api.Energy.Models
{
    public class LojaModel
    {
        public int LojaId { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }

        // Relacionamento com Pedido
        public List<PedidoModel> Pedidos { get; set; }
    }
}