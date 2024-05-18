﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPlanilla.DTO
{
    public class PaisDTO
    {
        public int Codigo { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<DepartamentoDTO>? Departamentos { get; set; }
    }
}
