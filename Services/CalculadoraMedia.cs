namespace Fiap.Api.Energy.Services
{
    public class CalculadoraMedia : ICalculadoraMedia
    {
        public decimal MediaConsumo(decimal precoFatura, decimal consumoKwh)
        {
            if(consumoKwh == 0)
            {
                throw new DivideByZeroException("Consumo não pode ter valor 0!");
                
            } else
            {
                return precoFatura / consumoKwh;
            }
        }
    }
}
