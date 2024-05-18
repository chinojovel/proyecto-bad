using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanilla.DTO
{
    public class SesionDTO
    {
        public int CodUsuario { get; set; }

        public string? NombreUsuario { get; set; }

        public string? Correo {  get; set; }

        public string? NombreRol {  get; set; }
    }
}
