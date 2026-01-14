using Domain.Entities;
using Domain.Interfaces;

namespace Aplication.UseCases
{
    public class RegistrarDevolucion
    {
        private readonly IDevolucion _devolucionRepo;
        private readonly IProducto _productoRepo;

        public RegistrarDevolucion(IDevolucion devolucionRepo, IProducto productoRepo)
        {
            _devolucionRepo = devolucionRepo;
            _productoRepo = productoRepo;
        }

        public async Task EjecutarAsync(Devolucion devolucion)
        {
            var producto = await _productoRepo.ObtenerPorId(devolucion.ProductoId);
            if (producto == null) throw new Exception("Error: El producto no existe.");

            // VALIDACIÓN DE FLUJO LOGÍCO:
            // No tiene sentido devolver un producto que ya está en 'Mantenimiento' o que sigue 'Disponible'
            if (producto.Estado != "Vendido")
                throw new Exception($"Operación inválida: No se puede registrar la devolución de un equipo que figura como '{producto.Estado}'. Solo se aceptan equipos vendidos.");

            // Validación de descripción
            if (string.IsNullOrWhiteSpace(devolucion.Motivo))
                throw new Exception("Error: Debe ingresar un motivo detallado para el reporte técnico.");

            devolucion.FechaDevolucion = DateTime.Now;

            // CUMPLIR HU-03: Cambiar estado a Mantenimiento automáticamente
            producto.Estado = "Mantenimiento";
            await _productoRepo.Actualizar(producto);

            await _devolucionRepo.Registrar(devolucion);
        }
    }
}