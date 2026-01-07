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
            // 1. Buscamos el producto para validar que existe
            var producto = await _productoRepo.ObtenerPorId(devolucion.ProductoId);
            if (producto == null) throw new Exception("El producto no existe.");

            // 2. ASIGNACIÓN AUTOMÁTICA DE FECHA (Tu pregunta)
            devolucion.FechaDevolucion = DateTime.Now;

            // 3. CUMPLIR HU-03: Cambiar estado a Mantenimiento automáticamente
            producto.Estado = "Mantenimiento";
            await _productoRepo.Actualizar(producto);

            // 4. Guardar la devolución
            await _devolucionRepo.Registrar(devolucion);
        }
    }
}