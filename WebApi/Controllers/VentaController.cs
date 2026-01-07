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
    public class VentaController : ControllerBase
    {
        private readonly RegistrarVenta _registrarVenta;
        private readonly IVenta _ventaRepo;
        private readonly IMapper _mapper;

        public VentaController(RegistrarVenta registrarVenta, IVenta ventaRepo, IMapper mapper)
        {
            _registrarVenta = registrarVenta;
            _ventaRepo = ventaRepo;
            _mapper = mapper;
        }

        [HttpPost] // HU-05: Registro en tiempo real
        public async Task<IActionResult> Post([FromBody] VentaDTO dto)
        {
            try
            {
                var venta = _mapper.Map<Venta>(dto);
                await _registrarVenta.EjecutarAsync(venta);
                return Ok(new { mensaje = "Venta formalizada y stock actualizado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("reporte")] // HU-06: Base para reportes
        public async Task<IActionResult> GetReporte(DateTime inicio, DateTime fin)
        {
            var ventas = await _ventaRepo.ObtenerPorRangoFechas(inicio, fin);
            return Ok(ventas);
        }
    }
}