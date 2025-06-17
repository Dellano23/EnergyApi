namespace Fiap.Api.Energy.Services
{
    public interface ICalculadoraMedia
    {
        decimal MediaConsumo(decimal precoFatura, decimal consumoKwh);
    }
}




