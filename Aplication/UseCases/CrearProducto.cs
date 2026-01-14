using Domain.Entities;
using Domain.Interfaces;

namespace Aplication.UseCases
{
    public class CrearProducto
    {
        private readonly IProducto _repo;
        public CrearProducto(IProducto repo) => _repo = repo;

        public async Task EjecutarAsync(Producto producto)
        {
            // 1. Validación de Formato de IMEI (15 dígitos numéricos)
            if (string.IsNullOrEmpty(producto.IMEI) || producto.IMEI.Length != 15 || !producto.IMEI.All(char.IsDigit))
                throw new Exception("El IMEI debe tener exactamente 15 dígitos numéricos.");

            // 2. Validación de Duplicidad
            var existeImei = await _repo.ObtenerPorIMEI(producto.IMEI);
            if (existeImei != null)
                throw new Exception($"El IMEI {producto.IMEI} ya está registrado. No puede haber duplicados.");

            // 3. Inicialización de estado
            producto.Estado = "Disponible";
            await _repo.Crear(producto);
        }
    }
}