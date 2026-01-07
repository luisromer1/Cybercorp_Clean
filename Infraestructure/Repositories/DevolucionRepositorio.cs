using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class DevolucionRepositorio : IDevolucion
    {
        private readonly CyberCorpDbContext _context;
        public DevolucionRepositorio(CyberCorpDbContext context) => _context = context;

        public async Task Registrar(Devolucion devolucion) { _context.Set<Devolucion>().Add(devolucion); await _context.SaveChangesAsync(); }
        public async Task<IEnumerable<Devolucion>> ObtenerPorProducto(int productoId) =>
            await _context.Set<Devolucion>().Where(d => d.ProductoId == productoId).ToListAsync();
    }
}