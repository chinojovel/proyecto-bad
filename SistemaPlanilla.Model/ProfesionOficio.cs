using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class ProfesionOficio
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
