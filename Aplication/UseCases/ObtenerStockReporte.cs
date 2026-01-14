using Aplication.DTOs;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases
{
    public class ObtenerStockReporte
    {
        private readonly IProducto _repo;
        public ObtenerStockReporte(IProducto repo) => _repo = repo;

        public async Task<StockReporteDTO> EjecutarAsync()
        {
            var productos = await _repo.ObtenerTodos();

            return new StockReporteDTO
            {
                Disponibles = productos.Count(p => p.Estado == "Disponible"),
                Vendidos = productos.Count(p => p.Estado == "Vendido"),
                EnMantenimiento = productos.Count(p => p.Estado == "Mantenimiento")
            };
        }
    }
}
