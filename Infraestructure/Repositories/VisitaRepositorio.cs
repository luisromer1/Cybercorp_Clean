using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VisitaRepositorio : IVisita
    {
        private readonly CyberCorpDbContext _context;

        public VisitaRepositorio(CyberCorpDbContext context)
        {
            _context = context;
        }

        public async Task Crear(Visita visita)
        {
            _context.Visitas.Add(visita);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Visita>> ObtenerTodas()
        {
            return await _context.Visitas.Include(v => v.Usuario).ToListAsync();
        }
    }
}
