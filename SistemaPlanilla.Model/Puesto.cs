using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class Puesto
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal SalarioMin { get; set; }

    public decimal SalarioMax { get; set; }

    public int CodEmpresa { get; set; }

    public int CodSubunidad { get; set; }

    public virtual Empresa CodEmpresaNavigation { get; set; } = null!;

    public virtual SubUnidad CodSubunidadNavigation { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
