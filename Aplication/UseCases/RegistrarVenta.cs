using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
namespace Aplication.UseCases
{
    public class RegistrarVenta
    {
        private readonly IVenta _ventaRepo;
        private readonly IProducto _productoRepo;

        public RegistrarVenta(IVenta ventaRepo, IProducto productoRepo)
        {
            _ventaRepo = ventaRepo;
            _productoRepo = productoRepo;
        }

        public async Task EjecutarAsync(Venta venta)
        {
            var producto = await _productoRepo.ObtenerPorId(venta.ProductoId);
            if (producto == null || producto.Estado != "Disponible")
                throw new Exception("Producto no disponible.");

            // Al vender, cambiamos el estado automáticamente
            producto.Estado = "Vendido";
            await _productoRepo.Actualizar(producto);

            venta.FechaVenta = DateTime.Now;
            await _ventaRepo.Crear(venta);
        }
    }
}
