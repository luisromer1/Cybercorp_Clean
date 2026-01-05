using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class VisitaDTO
    {
        public Guid UsuarioId { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
    }
}
