using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class Municipio
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public int CodDepartamento { get; set; }

    public virtual Departamento CodDepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
}
