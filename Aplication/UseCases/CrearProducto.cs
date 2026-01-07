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
            // HU-01: Validamos que el producto inicie como Disponible
            producto.Estado = "Disponible";
            await _repo.Crear(producto);
        }
    }
}