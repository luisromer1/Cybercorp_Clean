using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class ProductoRepositorio : IProducto
    {
        private readonly CyberCorpDbContext _context;
        public ProductoRepositorio(CyberCorpDbContext context) => _context = context;

        public async Task Crear(Producto producto) { _context.Productos.Add(producto); await _context.SaveChangesAsync(); }
        public async Task Actualizar(Producto producto) { _context.Productos.Update(producto); await _context.SaveChangesAsync(); }
        public async Task<Producto?> ObtenerPorId(int id) => await _context.Productos.FindAsync(id);
        public async Task<Producto?> ObtenerPorIMEI(string imei) => await _context.Productos.FirstOrDefaultAsync(p => p.IMEI == imei);
        public async Task<IEnumerable<Producto>> ObtenerTodos() => await _context.Productos.ToListAsync();
    }
}