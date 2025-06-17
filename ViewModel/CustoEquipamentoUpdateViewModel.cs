using Fiap.Api.Energy.Models;

namespace Fiap.Api.Energy.ViewModel
{
    public class CustoEquipamentoUpdateViewModel
    {
        public int CustoId { get; set; }
        public decimal ValorKwh { get; set; } //

        public int EquipamentoId { get; set; } //

        public decimal CustoEquipamentoDia { get; set; }

        public decimal CustoEquipamentoMensal { get; set; }
    }
}
