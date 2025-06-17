using Fiap.Api.Energy.Data.Contexts;
using Fiap.Api.Energy.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Energy.Data.Repository
{
    public class CustoEquipamentoRepository : ICustoEquipamentoRepository
    {
        private readonly DatabaseContext _context;

        public CustoEquipamentoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(CustoEquipamentoModel custoEquipamento)
        {
            _context.CustoEquipamento.Add(custoEquipamento);
            _context.SaveChanges();

        }

        public void Delete(CustoEquipamentoModel custoEquipamento)
        {
            _context.CustoEquipamento.Remove(custoEquipamento);
            _context.SaveChanges();
        }

        public IEnumerable<CustoEquipamentoModel> GetAll()
        {
            return _context.CustoEquipamento.ToList();
        }

        public IEnumerable<CustoEquipamentoModel> GetAllWithDetails()
        {
            return _context.CustoEquipamento
                .Include(p => p.Equipamento) 
                .ToList();
        }

        public CustoEquipamentoModel GetById(int id)
        {
            return _context.CustoEquipamento.Find(id);
        }

        public void Update(CustoEquipamentoModel custoEquipamento)
        {
            _context.CustoEquipamento.Update(custoEquipamento);
            _context.SaveChanges();
        }
    }
}
