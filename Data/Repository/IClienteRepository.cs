using Fiap.Api.Energy.Models;

namespace Fiap.Api.Energy.Data.Repository
{
    public interface IClienteRepository
    {
        IEnumerable<ClienteModel> GetAll();

        IEnumerable<ClienteModel> GetAllPag(int page, int size);
        ClienteModel GetById(int id);
        void Add(ClienteModel cliente);
        void Update(ClienteModel cliente);
        void Delete(ClienteModel cliente);
    }
}