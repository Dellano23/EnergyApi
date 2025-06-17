namespace Fiap.Api.Energy.Models
{
    public class EquipamentoModel
    {
        public int EquipamentoId { get; set; }
        public string EquipamentoNome { get; set; }
        public decimal Potencia { get; set; }
        public int UsoMinutoDia { get; set; } //no dia

  
    }
}
