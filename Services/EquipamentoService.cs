using Fiap.Api.Energy.Data.Repository;
using Fiap.Api.Energy.Models;

namespace Fiap.Api.Energy.Services
{
    public class EquipamentoService : IEquipamentoService
    {
        private readonly IEquipamentoRepository _repository;

        public EquipamentoService(IEquipamentoRepository repository)
        {
            _repository = repository;
        }

        public void AtualizarEquipamento(EquipamentoModel equipamento) =>
            _repository.Update(equipamento);
  

        public void CriarEquipamento(EquipamentoModel equipamento) =>
            _repository.Add(equipamento);
        public void DeletarEquipamento(int id)
        {
            var equipamento = _repository.GetById(id);
            if (equipamento != null)
            {
                _repository.Delete(equipamento);
            }
        }

        public IEnumerable<EquipamentoModel> ListarEquipamentos() =>
            _repository.GetAll();

        public EquipamentoModel ObterEquipamentoPorId(int id) =>
            _repository.GetById(id);
        
    }
}
