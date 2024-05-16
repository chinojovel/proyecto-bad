using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class Usuario
{
    public int Codigo { get; set; }

    public string Correo { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int CodEmpleado { get; set; }

    public int CodRol { get; set; }

    public int? IntentosLogin { get; set; }

    public bool Activo { get; set; }

    public virtual Empleado CodEmpleadoNavigation { get; set; } = null!;

    public virtual Rol CodRolNavigation { get; set; } = null!;
}
