using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
namespace Domain.Interfaces
{
    public interface IVenta
    {
        Task Crear(Venta venta);
        Task<IEnumerable<Venta>> ObtenerTodas();
        Task<IEnumerable<Venta>> ObtenerPorRangoFechas(DateTime inicio, DateTime fin);
    }
}
