using AutoMapper;
using Fiap.Api.Energy.Data.Repository;
using Fiap.Api.Energy.Models;
using Fiap.Api.Energy.ViewModel;

namespace Fiap.Api.Energy.Services
{
    public class EquipamentoService : IEquipamentoService
    {
        private readonly IEquipamentoRepository _repository;

        private readonly IMapper _mapper;

        public EquipamentoService(IEquipamentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AtualizarEquipamento(EquipamentoModel equipamento) =>
            _repository.Update(equipamento);


        public void CriarEquipamento(EquipamentoCreateViewModel equipamentoCreate)
        {
            var equipamento = _mapper.Map<EquipamentoModel>(equipamentoCreate);

            _repository.Add(equipamento);
        }
            
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


        //get com paginacao
        public IEnumerable<EquipamentoModel> ListarEquipamentos(int pagina = 1, int tamanho = 10)
        {
            return _repository.GetAllPag(pagina, tamanho);
        }

        public EquipamentoModel ObterEquipamentoPorId(int id) =>
            _repository.GetById(id);
        
    }
}
