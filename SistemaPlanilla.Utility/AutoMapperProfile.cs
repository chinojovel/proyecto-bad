using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SistemaPlanilla.DTO;
using SistemaPlanilla.Model;

namespace SistemaPlanilla.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Permiso
            CreateMap<Permiso, PermisoDTO>().ReverseMap();
            #endregion Permiso

            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion Rol

            #region PermisoRol
            CreateMap<PermisoRol, PermisoRolDTO>()
                .ForMember(
                    destino => destino.NombreRol,
                    opt => opt.MapFrom(origen => origen.CodRolNavigation.Nombre)
                )
                .ForMember(
                    destino => destino.NombrePermiso,
                    opt => opt.MapFrom(origen => origen.CodPermisoNavigation.Nombre)
                );

            CreateMap<PermisoRolDTO, PermisoRol>()
                .ForMember(
                    destino => destino.CodRolNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(
                    destino => destino.CodPermisoNavigation,
                    opt => opt.Ignore()
                );
            #endregion PermisoRol

            #region EstadoCivil
            CreateMap<EstadoCivil, EstadoCivilDTO>().ReverseMap();
            #endregion EstadoCivil

            #region Sexo
            CreateMap<Sexo, SexoDTO>().ReverseMap();
            #endregion Sexo

            #region ProfesionOficio
            CreateMap<ProfesionOficio, ProfesionOficioDTO>().ReverseMap();
            #endregion ProfesionOficio

            #region Pais
            CreateMap<Pais, PaisDTO>().ReverseMap();
            #endregion Pais

            #region Departamento
            CreateMap<Departamento, DepartamentoDTO>()
                .ForMember(
                    destino => destino.NombrePais,
                    opt => opt.MapFrom(origen => origen.CodPaisNavigation.Nombre)
                );

            CreateMap<DepartamentoDTO, Departamento>()
                .ForMember(
                    destino => destino.CodPaisNavigation,
                    opt => opt.Ignore()
                );
            #endregion Departamento

            #region Municipio
            CreateMap<Municipio, MunicipioDTO>()
                .ForMember(
                    destino => destino.NombreDepartamento,
                    opt => opt.MapFrom(origen => origen.CodDepartamentoNavigation.Nombre)
                );

            CreateMap<MunicipioDTO, Municipio>()
                .ForMember(
                    destino => destino.CodDepartamentoNavigation,
                    opt => opt.Ignore()
                );
            #endregion Municipio

            #region Empresa
            CreateMap<Empresa, EmpresaDTO>()
                .ForMember(
                    destino => destino.NombreMunicipio,
                    opt => opt.MapFrom(origen => origen.CodMunicipioNavigation.Nombre)
                );

            CreateMap<EmpresaDTO, Empresa>()
                .ForMember(
                    destino => destino.CodMunicipioNavigation,
                    opt => opt.Ignore()
                );
            #endregion Empresa

            #region DtopUnidad
            CreateMap<DptoUnidad, DptoUnidadDTO>()
                .ForMember(
                    destino => destino.NombreEmpresa,
                    opt => opt.MapFrom(origen => origen.CodEmpresaNavigation.Nombre)
                );

            CreateMap<DepartamentoDTO, DptoUnidad>()
                .ForMember(
                    destino => destino.CodEmpresaNavigation,
                    opt => opt.Ignore()
                );
            #endregion DtopUnidad

            #region CentroCosto
            CreateMap<CentroCosto, CentroCostoDTO>()
                .ForMember(
                    destino => destino.NombreDpto,
                    opt => opt.MapFrom(origen => origen.CodDptoNavigation.Nombre)
                );

            CreateMap<CentroCostoDTO, CentroCosto>()
                .ForMember(
                    destino => destino.CodDptoNavigation,
                    opt => opt.Ignore()
                );
            #endregion CentroCosto

            #region Area
            CreateMap<Area, AreaDTO>()
                .ForMember(
                    destino => destino.NombreDpto,
                    opt => opt.MapFrom(origen => origen.CodDptoNavigation.Nombre)
                );

            CreateMap<AreaDTO, Area>()
                .ForMember(
                    destino => destino.CodDptoNavigation,
                    opt => opt.Ignore()
                );
            #endregion Area

            #region SubUnidad
            CreateMap<SubUnidad, SubUnidadDTO>()
                .ForMember(
                    destino => destino.NombreArea,
                    opt => opt.MapFrom(origen => origen.CodAreaNavigation.Nombre)
                )
                .ForMember(
                    destino => destino.NombreUnidadPadre,
                    opt => opt.MapFrom(origen => origen.CodUnidadPadreNavigation.Nombre)
                );

            CreateMap<SubUnidadDTO, SubUnidad>()
                .ForMember(
                    destino => destino.CodAreaNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(
                    destino => destino.CodUnidadPadreNavigation,
                    opt => opt.Ignore()
                );
            #endregion SubUnidad

            #region Puesto
            CreateMap<Puesto, PuestoDTO>()
                .ForMember(
                    destino => destino.NombreEmpresa,
                    opt => opt.MapFrom(origen => origen.CodEmpresaNavigation.Nombre)
                )
                .ForMember(
                    destino => destino.NombreSubUnidad,
                    opt => opt.MapFrom(origen => origen.CodSubunidadNavigation.Nombre)
                );

            CreateMap<PuestoDTO, Puesto>()
                .ForMember(
                    destino => destino.CodEmpresaNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(
                    destino => destino.CodSubunidadNavigation,
                    opt => opt.Ignore()
                );
            #endregion Puesto

            #region Empleado
            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(
                    destino => destino.NombreSexo,
                    opt => opt.MapFrom(origen => origen.CodSexoNavigation.Nombre)
                )
                .ForMember(
                    destino => destino.NombreEstadoCivil,
                    opt => opt.MapFrom(origen => origen.CodEstadoCivilNavigation.Nombre)
                )
                .ForMember(
                    destino => destino.NombreMunicipio,
                    opt => opt.MapFrom(origen => origen.CodMunicipioNavigation.Nombre)
                )
                .ForMember(
                    destino => destino.NombreProfesion,
                    opt => opt.MapFrom(origen => origen.CodProfesionNavigation.Nombre)
                )
                .ForMember(
                    destino => destino.NombreEmpresa,
                    opt => opt.MapFrom(origen => origen.CodEmpresaNavigation.Nombre)
                )
                .ForMember(
                    destino => destino.NombrePuesto,
                    opt => opt.MapFrom(origen => origen.CodPuestoNavigation.Nombre)
                )
                .ForMember(
                    destino => destino.NombreJefe,
                    opt => opt.MapFrom(origen => origen.CodJefeNavigation.PrimerNombre + " " + origen.CodJefeNavigation.ApellidoPaterno)
                );

            CreateMap<EmpleadoDTO, Empleado>()
                .ForMember(
                    destino => destino.CodSexoNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(
                    destino => destino.CodEstadoCivilNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(
                    destino => destino.CodMunicipioNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(
                    destino => destino.CodProfesionNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(
                    destino => destino.CodEmpresaNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(
                    destino => destino.CodPuestoNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(
                    destino => destino.CodJefeNavigation,
                    opt => opt.Ignore()
                );
            #endregion Empleado

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(
                    destino => destino.NombreEmpleado,
                    opt => opt.MapFrom(origen => origen.CodEmpleadoNavigation.PrimerNombre + " " + origen.CodEmpleadoNavigation.ApellidoPaterno)
                )
                .ForMember(
                    destino => destino.NombreRol,
                    opt => opt.MapFrom(origen => origen.CodRolNavigation.Nombre)
                );

            CreateMap<Usuario, SesionDTO>()
                .ForMember(
                    destino => destino.NombreUsuario,
                    opt => opt.MapFrom(origen => origen.CodEmpleadoNavigation.PrimerNombre + " " + origen.CodEmpleadoNavigation.ApellidoPaterno)
                )
                .ForMember(
                    destino => destino.NombreRol,
                    opt => opt.MapFrom(origen => origen.CodRolNavigation.Nombre)
                );

            CreateMap<UsuarioDTO, Usuario>()
                .ForMember(
                    destino => destino.CodEmpleadoNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(
                    destino => destino.CodRolNavigation,
                    opt => opt.Ignore()
                );
            #endregion Usuario

            #region Planilla
            CreateMap<Planilla, PlanillaDTO>()
                .ForMember(
                    destino => destino.NombreEmpresa,
                    opt => opt.MapFrom(origen => origen.CodEmpresaNavigation.Nombre)
                )
                .ForMember(
                    destino => destino.NombreEmpleado,
                    opt => opt.MapFrom(origen => origen.CodEmpleadoNavigation.PrimerNombre + " " + origen.CodEmpleadoNavigation.ApellidoPaterno)
                );

            CreateMap<PlanillaDTO, Planilla>()
                .ForMember(
                    destino => destino.CodEmpresaNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(
                    destino => destino.CodEmpleadoNavigation,
                    opt => opt.Ignore()
                );
            #endregion Planilla
        }
    }
}
