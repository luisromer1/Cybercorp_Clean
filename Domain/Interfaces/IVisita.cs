using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVisita
    {
        Task<IEnumerable<Visita>> ObtenerTodas();
        Task Crear(Visita visita);
    }
}
