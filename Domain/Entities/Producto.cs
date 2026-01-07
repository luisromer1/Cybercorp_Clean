using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; } 
        public string Nombre { get; set; } = string.Empty;
        public string IMEI { get; set; } = string.Empty; 
        public string Estado { get; set; } = "Disponible";
    }
}
