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
        private readonly CrearProducto _crearProducto; // Caso de Uso para HU-01
        private readonly IMapper _mapper;

        public ProductoController(IProducto repo, CrearProducto crearProducto, IMapper mapper)
        {
            _repo = repo;
            _crearProducto = crearProducto;
            _mapper = mapper;
        }

        [HttpGet] // HU-08: Consultar inventario disponible
        public async Task<IActionResult> GetAll()
        {
            var productos = await _repo.ObtenerTodos();
            return Ok(productos);
        }

        [HttpGet("buscar/{imei}")] // HU-02: Buscar por IMEI
        public async Task<IActionResult> GetByImei(string imei)
        {
            var p = await _repo.ObtenerPorIMEI(imei);
            return p == null ? NotFound(new { mensaje = "Producto no encontrado" }) : Ok(p);
        }

        [HttpPost] // HU-01 y HU-07: Registro con validación
        public async Task<IActionResult> Create([FromBody] ProductoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.IMEI) || string.IsNullOrEmpty(dto.Nombre))
                return BadRequest(new { mensaje = "Datos incompletos: IMEI y Nombre son obligatorios" });

            var producto = _mapper.Map<Producto>(dto);
            await _crearProducto.EjecutarAsync(producto);

            return CreatedAtAction(nameof(GetByImei), new { imei = producto.IMEI }, producto);
        }

        [HttpPut("actualizar-estado")] // HU-04: Actualizar situación real
        public async Task<IActionResult> UpdateEstado(int id, string nuevoEstado)
        {
            var p = await _repo.ObtenerPorId(id);
            if (p == null) return NotFound();

            p.Estado = nuevoEstado;
            await _repo.Actualizar(p);
            return Ok(new { mensaje = $"Estado actualizado a {nuevoEstado}" });
        }
    }
}