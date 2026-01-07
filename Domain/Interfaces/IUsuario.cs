using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsuario
    {
        Task Crear(Usuario usuario);
        Task<IEnumerable<Usuario>> ObtenerTodos(); // Nombre unificado
    }
}