using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuario
    {
        Task<IEnumerable<Usuario>> ObtenerTodos();
        Task Crear(Usuario usuario);
    }
}
