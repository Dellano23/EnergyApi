using AutoMapper;
using Fiap.Api.Energy.Data.Repository;
using Fiap.Api.Energy.Models;
using Fiap.Api.Energy.ViewModel;

namespace Fiap.Api.Energy.Services
{
    public class CustoEquipamentoService : ICustoEquipamentoService
    {
        private readonly ICustoEquipamentoRepository _custoEquipamentoRepository;
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IMapper _mapper;

        public CustoEquipamentoService(ICustoEquipamentoRepository custoEquipamentoRepository, IMapper mapper, IEquipamentoRepository equipamentoRepository)
        {
            _custoEquipamentoRepository = custoEquipamentoRepository;
            _mapper = mapper;
            _equipamentoRepository = equipamentoRepository;
        }

        public CustoEquipamentoModel AdicionarCustoEquipamento(CustoEquipamentoViewModel custoEquipamentoViewModel)
        {
            // 1. Buscar o equipamento no banco
            var equipamento = _equipamentoRepository.GetById(custoEquipamentoViewModel.EquipamentoId);

            if (equipamento == null)
                throw new ArgumentException("Equipamento não encontrado.");

            // 2. Calcular consumo em kWh por dia
            // Fórmula: (potência em W * minutos/dia) / 1000 / 60
            var consumoKwhDia = (equipamento.Potencia * equipamento.UsoMinutoDia) / 1000m / 60m;

            // 3. Calcular custos
            var custoDia = consumoKwhDia * custoEquipamentoViewModel.ValorKwh;
            var custoMes = custoDia * 30;

            // 4. Montar a model completa
            var custoModel = new CustoEquipamentoModel
            {
                ValorKwh = custoEquipamentoViewModel.ValorKwh,
                EquipamentoId = custoEquipamentoViewModel.EquipamentoId,
                Equipamento = equipamento,
                CustoEquipamentoDia = Math.Round(custoDia, 2),
                CustoEquipamentoMensal = Math.Round(custoMes, 2)
            };

            // 5. Persistir no banco
            _custoEquipamentoRepository.Add(custoModel);

            return custoModel;
        }



        public void AtualizarCustoEquipamento(CustoEquipamentoModel custoEquipamento)
        {
            _custoEquipamentoRepository.Update(custoEquipamento);
        }

        public void DeletarCustoEquipamento(int id)
        {
            var custoEquipamento = _custoEquipamentoRepository.GetById(id);
            if (custoEquipamento != null)
            {
                _custoEquipamentoRepository.Delete(custoEquipamento);
            } else
            {
               throw new ArgumentException("Custo de equipamento não encontrado.");
            }
        }

        public CustoEquipamentoModel ObterCustoEquipamentoPorId(int id)
        {
            return _custoEquipamentoRepository.GetById(id);
        }

        public CustoEquipamentoModel ObterCustoEquipamentoPorIdComDetalhes(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustoEquipamentoModel> ObterTodosEquipamentosComDetalhes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustoEquipamentoModel> ObterTodosEquipementos()
        {
            return _custoEquipamentoRepository.GetAll();
        }
    }
}
