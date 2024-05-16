using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class Departamento
{
    public int Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public int CodPais { get; set; }

    public virtual Pais CodPaisNavigation { get; set; } = null!;

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
