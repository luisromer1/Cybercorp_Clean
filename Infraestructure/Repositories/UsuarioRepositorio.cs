using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Infrastructure.Repositories
{
    public class UsuarioRepositorio : IUsuario
    {
        private readonly CyberCorpDbContext _context;

        public UsuarioRepositorio(CyberCorpDbContext context)
        {
            _context = context;
        }

        public async Task Crear(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodos()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}