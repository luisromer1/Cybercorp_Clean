using Aplication.DTOs;
using Aplication.UseCases;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevolucionController : ControllerBase
    {
        private readonly RegistrarDevolucion _registrarDevolucion;
        private readonly IMapper _mapper;

        public DevolucionController(RegistrarDevolucion registrarDevolucion, IMapper mapper)
        {
            _registrarDevolucion = registrarDevolucion;
            _mapper = mapper;
        }

        [HttpPost] // HU-03: Registrar devolución
        public async Task<IActionResult> Registrar([FromBody] DevolucionDTO dto)
        {
            try
            {
                var devolucion = _mapper.Map<Devolucion>(dto);

                // Aquí se asigna la fecha sola mediante DateTime.Now dentro del UseCase
                await _registrarDevolucion.EjecutarAsync(devolucion);

                return Ok(new { mensaje = "Devolución registrada. El producto pasó a Mantenimiento." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}