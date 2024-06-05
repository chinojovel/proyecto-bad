using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanilla.DTO
{
    public class AreaDTO
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; } = null!;

        public int CodDpto { get; set; }

        public string? NombreDpto {  get; set; }
    }
}
