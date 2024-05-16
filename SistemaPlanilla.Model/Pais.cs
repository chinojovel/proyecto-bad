using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class Pais
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
