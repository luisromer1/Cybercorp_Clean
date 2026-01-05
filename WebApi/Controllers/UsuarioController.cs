using Aplication.DTOs;
using Aplication.UseCases;
using Application.DTOs;
using Application.UseCases;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly CrearUsuario _crearUsuario;
        private readonly IMapper _mapper;

        public UsuarioController(CrearUsuario crearUsuario, IMapper mapper)
        {
            _crearUsuario = crearUsuario;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Crear(UsuarioDTO dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            await _crearUsuario.EjecutarAsync(usuario);
            return Ok(dto);
        }
    }
}
