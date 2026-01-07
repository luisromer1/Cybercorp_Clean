using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Devolucion
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public DateTime FechaDevolucion { get; set; }

        public Producto? Producto { get; set; }
    }
}
