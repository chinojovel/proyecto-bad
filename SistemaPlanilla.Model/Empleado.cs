using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class Empleado
{
    public int Codigo { get; set; }

    public string Dui { get; set; } = null!;

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public string? ApellidoCasada { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public int CodSexo { get; set; }

    public int CodEstadoCivil { get; set; }

    public int CodMunicipio { get; set; }

    public int CodProfesion { get; set; }

    public string? Pasaporte { get; set; }

    public string? Nit { get; set; }

    public int Nup { get; set; }

    public int Isss { get; set; }

    public string Email { get; set; } = null!;

    public DateTime FechaIngreso { get; set; }

    public int CodEmpresa { get; set; }

    public int CodPuesto { get; set; }

    public int? CodJefe { get; set; }

    public decimal Salario { get; set; }

    public virtual Empresa CodEmpresaNavigation { get; set; } = null!;

    public virtual EstadoCivil CodEstadoCivilNavigation { get; set; } = null!;

    public virtual Empleado? CodJefeNavigation { get; set; }

    public virtual Municipio CodMunicipioNavigation { get; set; } = null!;

    public virtual ProfesionOficio CodProfesionNavigation { get; set; } = null!;

    public virtual Puesto CodPuestoNavigation { get; set; } = null!;

    public virtual Sexo CodSexoNavigation { get; set; } = null!;

    public virtual ICollection<Empleado> InverseCodJefeNavigation { get; set; } = new List<Empleado>();

    public virtual ICollection<Planilla> Planillas { get; set; } = new List<Planilla>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
