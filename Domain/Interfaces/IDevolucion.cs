using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDevolucion
    {
        Task Registrar(Devolucion devolucion);
        Task<IEnumerable<Devolucion>> ObtenerPorProducto(int productoId);
    }
}
