using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
namespace Aplication.UseCases
{
    public class CrearUsuario
    {
        private readonly IUsuario _usuarioRepositorio;

        public CrearUsuario(IUsuario usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task EjecutarAsync(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new ArgumentException("El nombre es obligatorio");

            await _usuarioRepositorio.Crear(usuario);
        }
    }
}
