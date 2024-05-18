using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanilla.DTO
{
    public class MunicipioDTO
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; } = null!;

        public int CodDepartamento { get; set; }

        public string? NombreDepartamento { get; set; }
    }
}
