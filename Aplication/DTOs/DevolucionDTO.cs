using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class DevolucionDTO
    {
        public int ProductoId { get; set; }
        public string Motivo { get; set; } = string.Empty;
        // La fecha se asigna automáticamente en el Caso de Uso
    }
}
