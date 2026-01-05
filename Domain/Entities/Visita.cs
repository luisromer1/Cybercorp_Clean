using System;

namespace Domain.Entities
{
    public class Visita
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        // Esta es la Clave Foránea (el dato en la tabla)
        public Guid UsuarioId { get; set; }

        // --- ESTO ES LO QUE FALTA ---
        // Esta es la Propiedad de Navegación (el objeto relacionado)
        public virtual Usuario Usuario { get; set; } = null!;
        // ----------------------------

        public string Cliente { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}