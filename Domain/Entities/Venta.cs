using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int UsuarioId { get; set; } // Vendedor
        public DateTime FechaVenta { get; set; }
        public decimal Precio { get; set; }

        public Producto? Producto { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
