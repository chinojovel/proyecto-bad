using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanilla.DTO
{
    public class PermisoRolDTO
    {
        public int Codigo { get; set; }

        public int CodRol { get; set; }

        public string? NombreRol { get; set; }

        public int CodPermiso { get; set; }

        public string? NombrePermiso { get; set; }
    }
}
