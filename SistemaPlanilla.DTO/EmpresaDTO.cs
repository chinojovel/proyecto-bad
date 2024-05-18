using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanilla.DTO
{
    public class EmpresaDTO
    {
        public int Codigo { get; set; }

        public string Nit { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Representante { get; set; } = null!;

        public int CodMunicipio { get; set; }

        public string? NombreMunicipio {  set; get; }

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string PaginaWeb { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool PlanillaMensual { get; set; }

        public virtual ICollection<DptoUnidadDTO>? DptosUnidades { get; set; }

        public virtual ICollection<EmpleadoDTO>? Empleados { get; set; }

        public virtual ICollection<PlanillaDTO>? Planillas { get; set; }

        public virtual ICollection<PuestoDTO>? Puestos { get; set; }
    }
}
