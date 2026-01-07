using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class VentaDTO
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int UsuarioId { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}
