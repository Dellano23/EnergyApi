namespace Fiap.Api.Energy.ViewModel
{
    public class EquipamentoViewModel
    {

        public int EquipamentoId { get; set; }
        public string EquipamentoNome { get; set; }
        public decimal Potencia { get; set; }
        public int UsoMinutoDia { get; set; } //no dia
    }
}
