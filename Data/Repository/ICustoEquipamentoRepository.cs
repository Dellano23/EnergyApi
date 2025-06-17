using Fiap.Api.Energy.Models;

namespace Fiap.Api.Energy.Data.Repository
{
    public interface ICustoEquipamentoRepository
    {
        IEnumerable<CustoEquipamentoModel> GetAll();

        IEnumerable<CustoEquipamentoModel> GetAllWithDetails();


        //IEnumerable<CustoEquipamentoModel> GetAllPag(int page, int size);
        CustoEquipamentoModel GetById(int id);
        void Add(CustoEquipamentoModel custoEquipamento);
        void Update(CustoEquipamentoModel custoEquipamento);
        void Delete(CustoEquipamentoModel custoEquipamento);
    }
}
