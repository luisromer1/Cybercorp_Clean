using Aplication.DTOs;
using Aplication.UseCases;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProducto _repo;
        private readonly CrearProducto _crearProducto;
        private readonly IMapper _mapper;
        private readonly ObtenerStockReporte _obtenerStock; // 1. Declarado correctamente

        // CORRECCIÓN AQUÍ: Debes agregar "ObtenerStockReporte obtenerStock" al paréntesis
        public ProductoController(
            IProducto repo,
            CrearProducto crearProducto,
            IMapper mapper,
            ObtenerStockReporte obtenerStock) // 2. Se recibe por parámetro
        {
            _repo = repo;
            _crearProducto = crearProducto;
            _mapper = mapper;
            _obtenerStock = obtenerStock; // 3. Se asigna el valor
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _repo.ObtenerTodos();
            return Ok(productos);
        }

        [HttpGet("buscar/{imei}")]
        public async Task<IActionResult> GetByImei(string imei)
        {
            var p = await _repo.ObtenerPorIMEI(imei);
            return p == null ? NotFound(new { mensaje = "Producto no encontrado" }) : Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.IMEI) || string.IsNullOrEmpty(dto.Nombre))
                return BadRequest(new { mensaje = "Datos incompletos: IMEI y Nombre son obligatorios" });

            var producto = _mapper.Map<Producto>(dto);
            await _crearProducto.EjecutarAsync(producto);

            return CreatedAtAction(nameof(GetByImei), new { imei = producto.IMEI }, producto);
        }

        [HttpPut("actualizar-estado")]
        public async Task<IActionResult> UpdateEstado(int id, string nuevoEstado)
        {
            var p = await _repo.ObtenerPorId(id);
            if (p == null) return NotFound();

            p.Estado = nuevoEstado;
            await _repo.Actualizar(p);
            return Ok(new { mensaje = $"Estado actualizado a {nuevoEstado}" });
        }

        // Este es el nuevo botón que verás en Swagger
        [HttpGet("stock-reporte")]
        public async Task<IActionResult> GetStockReporte()
        {
            var reporte = await _obtenerStock.EjecutarAsync();
            return Ok(reporte);
        }
    }
}