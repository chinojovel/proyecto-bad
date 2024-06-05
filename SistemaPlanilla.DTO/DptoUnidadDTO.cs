using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanilla.DTO
{
    public class DptoUnidadDTO
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; } = null!;

        public int CodEmpresa { get; set; }

        public string? NombreEmpresa { get; set; }
    }
}
