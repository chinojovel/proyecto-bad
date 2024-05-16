using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class Rol
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<PermisoRol> PermisoRols { get; set; } = new List<PermisoRol>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
