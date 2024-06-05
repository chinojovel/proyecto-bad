using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanilla.DTO
{
    public class EmpleadoDTO
    {
        public int Codigo { get; set; }

        public string Dui { get; set; } = null!;

        public string PrimerNombre { get; set; } = null!;

        public string? SegundoNombre { get; set; }

        public string ApellidoPaterno { get; set; } = null!;

        public string ApellidoMaterno { get; set; } = null!;

        public string? ApellidoCasada { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int CodSexo { get; set; }

        public string? NombreSexo { get; set; }

        public int CodEstadoCivil { get; set; }

        public string? NombreEstadoCivil { get; set; }

        public int CodMunicipio { get; set; }

        public string? NombreMunicipio { get; set; }

        public int CodProfesion { get; set; }

        public string? NombreProfesion { get; set; }

        public string? Pasaporte { get; set; }

        public string? Nit { get; set; }

        public int Nup { get; set; }

        public int Isss { get; set; }

        public string Email { get; set; } = null!;

        public DateTime FechaIngreso { get; set; }

        public int CodEmpresa { get; set; }

        public string? NombreEmpresa { get; set; }

        public int CodPuesto { get; set; }

        public string? NombrePuesto { get; set; }

        public int? CodJefe { get; set; }

        public string? NombreJefe { get; set; }

        public decimal Salario { get; set; }

        public virtual ICollection<EmpleadoDTO>? Empleados { get; set; }

        public virtual ICollection<UsuarioDTO>? Usuarios { get; set; }
    }
}
