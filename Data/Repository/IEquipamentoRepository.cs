using Fiap.Api.Energy.Models;

namespace Fiap.Api.Energy.Data.Repository
{
    public interface IEquipamentoRepository
    {
        IEnumerable<EquipamentoModel> GetAll();

        //IEnumerable<EquipamentoModel> GetAllPag(int page, int size);
        EquipamentoModel GetById(int id);
        void Add(EquipamentoModel equipamento);
        void Update(EquipamentoModel equipamento);
        void Delete(EquipamentoModel equipamento);
    }
}
