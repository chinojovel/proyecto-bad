using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using SistemaPlanilla.Model;

namespace SistemaPlanilla.DAL.DBContext;

public partial class Gp09planillasContext : DbContext
{
    public Gp09planillasContext()
    {
    }

    public Gp09planillasContext(DbContextOptions<Gp09planillasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<CentroCosto> CentroCostos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DptoUnidad> DptoUnidads { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PermisoRol> PermisoRols { get; set; }

    public virtual DbSet<Planilla> Planillas { get; set; }

    public virtual DbSet<ProfesionOficio> ProfesionOficios { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<SubUnidad> SubUnidads { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_area");

            entity.ToTable("Area");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CodDpto).HasColumnName("cod_dpto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.CodDptoNavigation).WithMany(p => p.Areas)
                .HasForeignKey(d => d.CodDpto)
                .HasConstraintName("FK_area_dptounidad");
        });

        modelBuilder.Entity<CentroCosto>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_centrocosto");

            entity.ToTable("CentroCosto");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CodDpto).HasColumnName("cod_dpto");
            entity.Property(e => e.FechaAsignacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaAsignacion");
            entity.Property(e => e.MontoActual)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("montoActual");
            entity.Property(e => e.MontoInicial)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("montoInicial");

            entity.HasOne(d => d.CodDptoNavigation).WithMany(p => p.CentroCostos)
                .HasForeignKey(d => d.CodDpto)
                .HasConstraintName("FK_centrocosto_dptounidad");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_departamento");

            entity.ToTable("Departamento");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CodPais).HasColumnName("cod_pais");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.CodPaisNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.CodPais)
                .HasConstraintName("FK_departamento_pais");
        });

        modelBuilder.Entity<DptoUnidad>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_dptounidad");

            entity.ToTable("DptoUnidad");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CodEmpresa).HasColumnName("cod_empresa");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.CodEmpresaNavigation).WithMany(p => p.DptoUnidads)
                .HasForeignKey(d => d.CodEmpresa)
                .HasConstraintName("FK_dptounidad_empresa");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_empleado");

            entity.ToTable("Empleado");

            entity.HasIndex(e => e.Dui, "UC_empleado_dui").IsUnique();

            entity.HasIndex(e => e.Nit, "UC_empleado_nit").IsUnique();

            entity.HasIndex(e => e.Pasaporte, "UC_empleado_pasaporte").IsUnique();

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.ApellidoCasada)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellidoCasada");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellidoMaterno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellidoPaterno");
            entity.Property(e => e.CodEmpresa).HasColumnName("cod_empresa");
            entity.Property(e => e.CodEstadoCivil).HasColumnName("cod_estado_civil");
            entity.Property(e => e.CodJefe).HasColumnName("cod_jefe");
            entity.Property(e => e.CodMunicipio).HasColumnName("cod_municipio");
            entity.Property(e => e.CodProfesion).HasColumnName("cod_profesion");
            entity.Property(e => e.CodPuesto).HasColumnName("cod_puesto");
            entity.Property(e => e.CodSexo).HasColumnName("cod_sexo");
            entity.Property(e => e.Dui)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("dui");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fechaIngreso");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.Isss).HasColumnName("isss");
            entity.Property(e => e.Nit)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nit");
            entity.Property(e => e.Nup).HasColumnName("nup");
            entity.Property(e => e.Pasaporte)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("pasaporte");
            entity.Property(e => e.PrimerNombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("primerNombre");
            entity.Property(e => e.Salario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salario");
            entity.Property(e => e.SegundoNombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("segundoNombre");

            entity.HasOne(d => d.CodEmpresaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CodEmpresa)
                .HasConstraintName("FK_empleado_empresa");

            entity.HasOne(d => d.CodEstadoCivilNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CodEstadoCivil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_empleado_estado");

            entity.HasOne(d => d.CodJefeNavigation).WithMany(p => p.InverseCodJefeNavigation)
                .HasForeignKey(d => d.CodJefe)
                .HasConstraintName("FK_empleado_jefe");

            entity.HasOne(d => d.CodMunicipioNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CodMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_empleado_municipio");

            entity.HasOne(d => d.CodProfesionNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CodProfesion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_empleado_profesion");

            entity.HasOne(d => d.CodPuestoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CodPuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_empleado_puesto");

            entity.HasOne(d => d.CodSexoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CodSexo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_empleado_sexo");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_empresa");

            entity.ToTable("Empresa");

            entity.HasIndex(e => e.Nit, "UC_empresa_nit").IsUnique();

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CodMunicipio).HasColumnName("cod_municipio");
            entity.Property(e => e.Direccion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nit)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nit");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PaginaWeb)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("paginaWeb");
            entity.Property(e => e.PlanillaMensual).HasColumnName("planillaMensual");
            entity.Property(e => e.Representante)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("representante");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.CodMunicipioNavigation).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.CodMunicipio)
                .HasConstraintName("FK_empresa_municipio");
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_estadocivil");

            entity.ToTable("EstadoCivil");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_municipio");

            entity.ToTable("Municipio");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CodDepartamento).HasColumnName("cod_departamento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.CodDepartamentoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.CodDepartamento)
                .HasConstraintName("FK_municipio_departamento");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_pais");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_permiso");

            entity.ToTable("Permiso");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<PermisoRol>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_permisorol");

            entity.ToTable("PermisoRol");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CodPermiso).HasColumnName("cod_permiso");
            entity.Property(e => e.CodRol).HasColumnName("cod_rol");

            entity.HasOne(d => d.CodPermisoNavigation).WithMany(p => p.PermisoRols)
                .HasForeignKey(d => d.CodPermiso)
                .HasConstraintName("FK_permisorol_permiso");

            entity.HasOne(d => d.CodRolNavigation).WithMany(p => p.PermisoRols)
                .HasForeignKey(d => d.CodRol)
                .HasConstraintName("FK_permisorol_rol");
        });

        modelBuilder.Entity<Planilla>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_planilla");

            entity.ToTable("Planilla");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.AfpEmpleado)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("afpEmpleado");
            entity.Property(e => e.AfpPatronal)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("afpPatronal");
            entity.Property(e => e.Aguinaldo)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("aguinaldo");
            entity.Property(e => e.CodEmpleado).HasColumnName("cod_empleado");
            entity.Property(e => e.CodEmpresa).HasColumnName("cod_empresa");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.HorasExtrasDiurnas)
                .HasDefaultValue(0)
                .HasColumnName("horasExtrasDiurnas");
            entity.Property(e => e.HorasExtrasNocturnas)
                .HasDefaultValue(0)
                .HasColumnName("horasExtrasNocturnas");
            entity.Property(e => e.HorasNocturnas)
                .HasDefaultValue(0)
                .HasColumnName("horasNocturnas");
            entity.Property(e => e.ImpuestoRenta)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("impuestoRenta");
            entity.Property(e => e.IsssEmpleado)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("isssEmpleado");
            entity.Property(e => e.IsssPatronal)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("isssPatronal");
            entity.Property(e => e.MontoEmpleado)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("montoEmpleado");
            entity.Property(e => e.MontoGravadoCotizable)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("montoGravadoCotizable");
            entity.Property(e => e.MontoPlanillaUnica)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("montoPlanillaUnica");
            entity.Property(e => e.Vacaciones)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("vacaciones");

            entity.HasOne(d => d.CodEmpleadoNavigation).WithMany(p => p.Planillas)
                .HasForeignKey(d => d.CodEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_planilla_empleado");

            entity.HasOne(d => d.CodEmpresaNavigation).WithMany(p => p.Planillas)
                .HasForeignKey(d => d.CodEmpresa)
                .HasConstraintName("FK_planilla_empresa");
        });

        modelBuilder.Entity<ProfesionOficio>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_profesionoficio");

            entity.ToTable("ProfesionOficio");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_puesto");

            entity.ToTable("Puesto");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CodEmpresa).HasColumnName("cod_empresa");
            entity.Property(e => e.CodSubunidad).HasColumnName("cod_subunidad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.SalarioMax)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salarioMax");
            entity.Property(e => e.SalarioMin)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("salarioMin");

            entity.HasOne(d => d.CodEmpresaNavigation).WithMany(p => p.Puestos)
                .HasForeignKey(d => d.CodEmpresa)
                .HasConstraintName("FK_puesto_empresa");

            entity.HasOne(d => d.CodSubunidadNavigation).WithMany(p => p.Puestos)
                .HasForeignKey(d => d.CodSubunidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_puesto_subunidad");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_rol");

            entity.ToTable("Rol");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_sexo");

            entity.ToTable("Sexo");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<SubUnidad>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_subunidad");

            entity.ToTable("SubUnidad");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.CodArea).HasColumnName("cod_area");
            entity.Property(e => e.CodUnidadPadre).HasColumnName("cod_unidad_padre");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.CodAreaNavigation).WithMany(p => p.SubUnidads)
                .HasForeignKey(d => d.CodArea)
                .HasConstraintName("FK_subunidad_area");

            entity.HasOne(d => d.CodUnidadPadreNavigation).WithMany(p => p.InverseCodUnidadPadreNavigation)
                .HasForeignKey(d => d.CodUnidadPadre)
                .HasConstraintName("FK_subunidad_unidadpadre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_usuario");

            entity.ToTable("Usuario");

            entity.Property(e => e.Codigo).HasColumnName("codigo");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.CodEmpleado).HasColumnName("cod_empleado");
            entity.Property(e => e.CodRol).HasColumnName("cod_rol");
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.IntentosLogin)
                .HasDefaultValue(0)
                .HasColumnName("intentosLogin");

            entity.HasOne(d => d.CodEmpleadoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.CodEmpleado)
                .HasConstraintName("FK_usuario_empleado");

            entity.HasOne(d => d.CodRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.CodRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuario_rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
