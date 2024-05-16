using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class Permiso
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<PermisoRol> PermisoRols { get; set; } = new List<PermisoRol>();
}
