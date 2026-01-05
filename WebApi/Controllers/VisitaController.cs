using Aplication.DTOs;
using Aplication.UseCases;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/visitas")]
    public class VisitaController : ControllerBase
    {
        private readonly RegistrarVisita _registrarVisita;
        private readonly IMapper _mapper;

        public VisitaController(RegistrarVisita registrarVisita, IMapper mapper)
        {
            _registrarVisita = registrarVisita;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(VisitaDTO dto)
        {
            var visita = _mapper.Map<Visita>(dto);
            await _registrarVisita.EjecutarAsync(visita);
            return Ok(dto);
        }
    }
}
