using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public class IUsuario
    {
        Task<IEnumerable<Usuario>> ObtenerTodos();
        Task Crear(Usuario usuario);
    }
}
