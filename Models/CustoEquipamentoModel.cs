namespace Fiap.Api.Energy.Models
{
    public class CustoEquipamentoModel
    {

        public int CustoId { get; set; }
        public decimal ValorKwh { get; set; } //

        public int EquipamentoId { get; set; } //

        public EquipamentoModel Equipamento { get; set; }

        public decimal CustoEquipamentoDia { get; set; }

        public decimal CustoEquipamentoMensal {  get; set; }
    }
}
