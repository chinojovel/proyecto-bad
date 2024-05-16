using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class DptoUnidad
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public int CodEmpresa { get; set; }

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();

    public virtual ICollection<CentroCosto> CentroCostos { get; set; } = new List<CentroCosto>();

    public virtual Empresa CodEmpresaNavigation { get; set; } = null!;
}
