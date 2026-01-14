using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class StockReporteDTO
    {
        public int Disponibles { get; set; }
        public int Vendidos { get; set; }
        public int EnMantenimiento { get; set; }
        public int TotalGeneral => Disponibles + Vendidos + EnMantenimiento;
    }
}
