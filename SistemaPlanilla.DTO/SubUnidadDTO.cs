using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanilla.DTO
{
    public class SubUnidadDTO
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; } = null!;

        public int CodArea { get; set; }

        public string? NombreArea { get; set; }

        public int? CodUnidadPadre { get; set; }

        public string? NombreUnidadPadre {  get; set; }

        public virtual ICollection<SubUnidadDTO>? SubUnidades { get; set; }

        public virtual ICollection<PuestoDTO>? Puestos { get; set; }
    }
}
