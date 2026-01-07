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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioRepo;
        private readonly CrearUsuario _crearUsuario;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuario usuarioRepo, CrearUsuario crearUsuario, IMapper mapper)
        {
            _usuarioRepo = usuarioRepo;
            _crearUsuario = crearUsuario;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _usuarioRepo.ObtenerTodos(); // Corregido: ya no da error CS1501
            if (!usuarios.Any()) return NotFound(new { mensaje = "Sin usuarios" });
            return Ok(_mapper.Map<IEnumerable<UsuarioDTO>>(usuarios));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioDTO dto)
        {
            try 
            {
                var usuario = _mapper.Map<Usuario>(dto);
                await _crearUsuario.EjecutarAsync(usuario);
                
                // Devolvemos el objeto creado con su nuevo ID
                return CreatedAtAction(nameof(GetAll), new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al crear usuario", detalle = ex.Message });
            }
        }
    }
}