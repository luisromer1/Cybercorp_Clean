using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class VentaRepositorio : IVenta
    {
        private readonly CyberCorpDbContext _context;
        public VentaRepositorio(CyberCorpDbContext context) => _context = context;

        public async Task Crear(Venta venta) { _context.Ventas.Add(venta); await _context.SaveChangesAsync(); }
        public async Task<IEnumerable<Venta>> ObtenerTodas() => await _context.Ventas.Include(v => v.Producto).ToListAsync();
        public async Task<IEnumerable<Venta>> ObtenerPorRangoFechas(DateTime inicio, DateTime fin) =>
            await _context.Ventas.Where(v => v.FechaVenta >= inicio && v.FechaVenta <= fin).Include(v => v.Producto).ToListAsync();
    }
}