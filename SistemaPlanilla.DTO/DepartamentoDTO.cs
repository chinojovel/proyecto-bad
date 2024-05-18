using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanilla.DTO
{
    public class DepartamentoDTO
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; } = null!;

        public int CodPais { get; set; }

        public string? NombrePais { get; set; }

        public virtual ICollection<MunicipioDTO>? Municipios { get; set; }
    }
}
