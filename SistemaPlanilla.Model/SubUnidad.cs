using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class SubUnidad
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public int CodArea { get; set; }

    public int? CodUnidadPadre { get; set; }

    public virtual Area CodAreaNavigation { get; set; } = null!;

    public virtual SubUnidad? CodUnidadPadreNavigation { get; set; }

    public virtual ICollection<SubUnidad> InverseCodUnidadPadreNavigation { get; set; } = new List<SubUnidad>();

    public virtual ICollection<Puesto> Puestos { get; set; } = new List<Puesto>();
}
