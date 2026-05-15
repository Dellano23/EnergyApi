using Fiap.Api.Energy.Models;
using Fiap.Api.Energy.ViewModel;

namespace Fiap.Api.Energy.Services
{
    public interface IEquipamentoService
    {
        IEnumerable<EquipamentoModel> ListarEquipamentos();

        IEnumerable<EquipamentoModel> ListarEquipamentos(int pagina = 0, int tamanho = 10);
        EquipamentoModel ObterEquipamentoPorId(int id);
        void CriarEquipamento(EquipamentoCreateViewModel equipamento);
        void AtualizarEquipamento(EquipamentoModel equipamento);
        void DeletarEquipamento(int id);
    }
}
