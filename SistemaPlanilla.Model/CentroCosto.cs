using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class CentroCosto
{
    public int Codigo { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public decimal MontoInicial { get; set; }

    public decimal MontoActual { get; set; }

    public int CodDpto { get; set; }

    public virtual DptoUnidad CodDptoNavigation { get; set; } = null!;
}
