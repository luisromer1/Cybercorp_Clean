using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
namespace Aplication.UseCases
{
    public class RegistrarVisita
    {
        private readonly IVisita _visitaRepositorio;

        public RegistrarVisita(IVisita visitaRepositorio)
        {
            _visitaRepositorio = visitaRepositorio;
        }

        public async Task EjecutarAsync(Visita visita)
        {
            if (string.IsNullOrWhiteSpace(visita.Cliente) ||
                string.IsNullOrWhiteSpace(visita.Ciudad))
                throw new ArgumentException("Datos incompletos");

            await _visitaRepositorio.Crear(visita);
        }
    }
}
