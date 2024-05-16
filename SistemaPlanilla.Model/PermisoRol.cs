using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class PermisoRol
{
    public int Codigo { get; set; }

    public int CodRol { get; set; }

    public int CodPermiso { get; set; }

    public virtual Permiso CodPermisoNavigation { get; set; } = null!;

    public virtual Rol CodRolNavigation { get; set; } = null!;
}
