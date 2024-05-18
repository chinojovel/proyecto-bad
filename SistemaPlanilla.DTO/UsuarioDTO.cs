using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanilla.DTO
{
    public class UsuarioDTO
    {
        public int Codigo { get; set; }

        public string Correo { get; set; } = null!;

        public string Contrasena { get; set; } = null!;

        public int CodEmpleado { get; set; }

        public string? NombreEmpleado { get; set; }

        public int CodRol { get; set; }

        public string? NombreRol {  get; set; }

        public int? IntentosLogin { get; set; }

        public bool Activo { get; set; }
    }
}
