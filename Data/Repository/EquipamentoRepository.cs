using Fiap.Api.Energy.Data.Contexts;
using Fiap.Api.Energy.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Energy.Data.Repository
{
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly DatabaseContext _context;

        public EquipamentoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(EquipamentoModel equipamento)
        {
            _context.Equipamento.Add(equipamento);
            _context.SaveChanges();
        }

        public void Delete(EquipamentoModel equipamento)
        {
            _context.Equipamento.Remove(equipamento);
            _context.SaveChanges();
        }

        public IEnumerable<EquipamentoModel> GetAll() =>
            _context.Equipamento.ToList();

        //get all com paginacao (database medio)
        public IEnumerable<EquipamentoModel> GetAllPag(int page, int size)
        {
            return _context.Equipamento
                .Skip((page - 1) * page)
                .Take(size)
                .AsNoTracking()
                .ToList();
        }

        public EquipamentoModel GetById(int id) => _context.Equipamento.Find(id);
        public void Update(EquipamentoModel equipamento)
        {
            _context.Equipamento.Update(equipamento);
            _context.SaveChanges(); 
        }
    }
}
