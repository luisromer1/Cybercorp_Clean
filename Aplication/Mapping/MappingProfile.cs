using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.DTOs;
using AutoMapper;
using Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Aplication.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Visita, VisitaDTO>().ReverseMap();
        }
    }
}
