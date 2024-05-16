using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class Area
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public int CodDpto { get; set; }

    public virtual DptoUnidad CodDptoNavigation { get; set; } = null!;

    public virtual ICollection<SubUnidad> SubUnidads { get; set; } = new List<SubUnidad>();
}
