using Fiap.Api.Energy.Data.Contexts;
using Fiap.Api.Energy.Data.Repository;
using Fiap.Api.Energy.Models;
using Microsoft.EntityFrameworkCore;

public class ClienteRepository : IClienteRepository
{
    private readonly DatabaseContext _context;

    public ClienteRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<ClienteModel> GetAll() => _context.Clientes.Include(c => c.Representante).ToList();

    //get all com paginacao (database medio)
    public IEnumerable<ClienteModel> GetAllPag(int page, int size)
    {
        return _context.Clientes
            .Include(c => c.Representante)
            .Skip((page - 1) * page)
            .Take(size)
            .AsNoTracking()
            .ToList();
    }

    public ClienteModel GetById(int id) => _context.Clientes.Find(id);

    public void Add(ClienteModel cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
    }

    public void Update(ClienteModel cliente)
    {
        _context.Update(cliente);
        _context.SaveChanges();
    }

    public void Delete(ClienteModel cliente)
    {
        _context.Clientes.Remove(cliente);
        _context.SaveChanges();
    }
}