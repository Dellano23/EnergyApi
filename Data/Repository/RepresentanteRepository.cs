using Fiap.Api.Energy.Data.Contexts;
using Fiap.Api.Energy.Models;

namespace Fiap.Api.Energy.Data.Repository
{
    public class RepresentanteRepository : IRepresentanteRepository
    {

        private readonly DatabaseContext _context;

        public RepresentanteRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<RepresentanteModel> GetAll() => _context.Representantes.ToList();

        public RepresentanteModel GetById(int id) => _context.Representantes.Find(id);

        public void Add(RepresentanteModel representante)
        {
            _context.Representantes.Add(representante);
            _context.SaveChanges();
        }

        public void Update(RepresentanteModel representante)
        {
            _context.Representantes.Update(representante);
            _context.SaveChanges();
        }

        public void Delete(RepresentanteModel representante)
        {
            _context.Representantes.Remove(representante);
            _context.SaveChanges();
        }
    }
}
