using Fiap.Api.Energy.Models;

namespace Fiap.Api.Energy.Services
{
    public interface IRepresentanteService
    {
        IEnumerable<RepresentanteModel> ListarRepresentantes();
        RepresentanteModel ObterRepresentantePorId(int id);
        void CriarRepresentante(RepresentanteModel representante);
        void AtualizarRepresentante(RepresentanteModel representante);
        void DeletarRepresentante(int id);

    }
}
