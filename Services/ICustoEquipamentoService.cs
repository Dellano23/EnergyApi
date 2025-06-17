using Fiap.Api.Energy.Models;
using Fiap.Api.Energy.ViewModel;

namespace Fiap.Api.Energy.Services
{
    public interface ICustoEquipamentoService
    {
        IEnumerable<CustoEquipamentoModel> ObterTodosEquipementos();
        IEnumerable<CustoEquipamentoModel> ObterTodosEquipamentosComDetalhes();
        CustoEquipamentoModel ObterCustoEquipamentoPorId(int id);
        CustoEquipamentoModel ObterCustoEquipamentoPorIdComDetalhes(int id);
        void AdicionarCustoEquipamento(CustoEquipamentoViewModel custoEquipamento);
        void AtualizarCustoEquipamento(CustoEquipamentoModel custoEquipamento);
        void DeletarCustoEquipamento(int id);
    }
}
