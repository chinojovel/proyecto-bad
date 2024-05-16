using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class Empresa
{
    public int Codigo { get; set; }

    public string Nit { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Representante { get; set; } = null!;

    public int CodMunicipio { get; set; }

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string PaginaWeb { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool PlanillaMensual { get; set; }

    public virtual Municipio CodMunicipioNavigation { get; set; } = null!;

    public virtual ICollection<DptoUnidad> DptoUnidads { get; set; } = new List<DptoUnidad>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Planilla> Planillas { get; set; } = new List<Planilla>();

    public virtual ICollection<Puesto> Puestos { get; set; } = new List<Puesto>();
}
