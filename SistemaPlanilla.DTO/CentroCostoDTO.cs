using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanilla.DTO
{
    public class CentroCostoDTO
    {
        public int Codigo { get; set; }

        public DateTime FechaAsignacion { get; set; }

        public decimal MontoInicial { get; set; }

        public decimal MontoActual { get; set; }

        public int CodDpto { get; set; }

        public string? NombreDpto { get; set; }
    }
}
