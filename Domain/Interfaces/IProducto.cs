using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProducto
    {
        Task Crear(Producto producto);
        Task Actualizar(Producto producto);
        Task<Producto?> ObtenerPorId(int id);
        Task<Producto?> ObtenerPorIMEI(string imei); 
        Task<IEnumerable<Producto>> ObtenerTodos();
    }
}
