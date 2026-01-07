using Domain.Entities;
using Domain.Interfaces;

namespace Aplication.UseCases
{
    public class CrearUsuario
    {
        private readonly IUsuario _usuarioRepo;

        public CrearUsuario(IUsuario usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public async Task EjecutarAsync(Usuario usuario)
        {
            // Ya no generamos Guid.NewGuid(). 
            // El ID se genera solo en la base de datos (1, 2, 3...).
            await _usuarioRepo.Crear(usuario);
        }
    }
}