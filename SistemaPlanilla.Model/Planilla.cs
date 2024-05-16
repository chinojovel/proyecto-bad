using System;
using System.Collections.Generic;

namespace SistemaPlanilla.Model;

public partial class Planilla
{
    public int Codigo { get; set; }

    public DateTime Fecha { get; set; }

    public int CodEmpresa { get; set; }

    public int CodEmpleado { get; set; }

    public int? HorasExtrasDiurnas { get; set; }

    public int? HorasExtrasNocturnas { get; set; }

    public int? HorasNocturnas { get; set; }

    public decimal? Vacaciones { get; set; }

    public decimal? Aguinaldo { get; set; }

    public decimal? MontoGravadoCotizable { get; set; }

    public decimal? AfpPatronal { get; set; }

    public decimal? AfpEmpleado { get; set; }

    public decimal? IsssPatronal { get; set; }

    public decimal? IsssEmpleado { get; set; }

    public decimal? ImpuestoRenta { get; set; }

    public decimal? MontoEmpleado { get; set; }

    public decimal? MontoPlanillaUnica { get; set; }

    public virtual Empleado CodEmpleadoNavigation { get; set; } = null!;

    public virtual Empresa CodEmpresaNavigation { get; set; } = null!;
}
