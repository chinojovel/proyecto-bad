using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanilla.DTO
{
    public class PuestoDTO
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public decimal SalarioMin { get; set; }

        public decimal SalarioMax { get; set; }

        public int CodEmpresa { get; set; }

        public string? NombreEmpresa { get; set; }

        public int CodSubunidad { get; set; }

        public string? NombreSubUnidad { get; set; }
    }
}
