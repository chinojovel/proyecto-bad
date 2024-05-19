using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaPlanilla.BLL.Servicios.Contrato;
using SistemaPlanilla.DAL.Repositorios.Contrato;
using SistemaPlanilla.DTO;
using SistemaPlanilla.Model;

namespace SistemaPlanilla.BLL.Servicios
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IGenericRepository<Empleado> _empleadoRepositorio;
        private readonly IMapper _mapper;

        public EmpleadoService(IGenericRepository<Empleado> empleadoRepositorio, IMapper mapper)
        {
            _empleadoRepositorio = empleadoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<EmpleadoDTO>> Listar()
        {
            try
            {
                var queryEmpleado = await _empleadoRepositorio.Consultar();
                var listaEmpleados = queryEmpleado
                    .Include(f => f.CodSexoNavigation)
                    .Include(f => f.CodEstadoCivilNavigation)
                    .Include(f => f.CodMunicipioNavigation)
                    .Include(f => f.CodProfesionNavigation)
                    .Include(f => f.CodEmpresaNavigation)
                    .Include(f => f.CodPuestoNavigation)
                    .Include(f => f.CodJefeNavigation)
                    .ToList();

                return _mapper.Map<List<EmpleadoDTO>>(listaEmpleados.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmpleadoDTO> Crear(EmpleadoDTO modelo)
        {
            try
            {
                var empleadoCreado = await _empleadoRepositorio.Crear(_mapper.Map<Empleado>(modelo));

                if (empleadoCreado.Codigo == 0)
                {
                    throw new TaskCanceledException("El empleado no pudo ser creado.");
                }

                return _mapper.Map<EmpleadoDTO>(empleadoCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(EmpleadoDTO modelo)
        {
            try
            {
                var empleadoModelo = _mapper.Map<Empleado>(modelo);
                var empleadoEncontrado = await _empleadoRepositorio.Obtener(u => u.Codigo == empleadoModelo.Codigo);

                if (empleadoEncontrado == null)
                {
                    throw new TaskCanceledException("El empleado no existe.");
                }

                empleadoEncontrado.Dui = empleadoModelo.Dui;
                empleadoEncontrado.PrimerNombre = empleadoModelo.PrimerNombre;
                empleadoEncontrado.SegundoNombre = empleadoModelo.SegundoNombre;
                empleadoEncontrado.ApellidoPaterno = empleadoModelo.ApellidoPaterno;
                empleadoEncontrado.ApellidoMaterno = empleadoModelo.ApellidoMaterno;
                empleadoEncontrado.ApellidoCasada = empleadoModelo.ApellidoCasada;
                empleadoEncontrado.FechaNacimiento = empleadoModelo.FechaNacimiento;
                empleadoEncontrado.CodSexo = empleadoModelo.CodSexo;
                empleadoEncontrado.CodEstadoCivil = empleadoModelo.CodEstadoCivil;
                empleadoEncontrado.CodMunicipio = empleadoModelo.CodMunicipio;
                empleadoEncontrado.CodProfesion = empleadoModelo.CodProfesion;
                empleadoEncontrado.Pasaporte = empleadoModelo.Pasaporte;
                empleadoEncontrado.Nit = empleadoModelo.Nit;
                empleadoEncontrado.Nup = empleadoModelo.Nup;
                empleadoEncontrado.Isss = empleadoModelo.Isss;
                empleadoEncontrado.Email = empleadoModelo.Email;
                empleadoEncontrado.FechaIngreso = empleadoModelo.FechaIngreso;
                empleadoEncontrado.CodEmpresa = empleadoModelo.CodEmpresa;
                empleadoEncontrado.CodPuesto = empleadoModelo.CodPuesto;
                empleadoEncontrado.CodJefe = empleadoModelo.CodJefe;
                empleadoEncontrado.Salario = empleadoModelo.Salario;

                bool response = await _empleadoRepositorio.Editar(empleadoEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El empleado no pudo ser editado.");
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var empleadoEncontrado = await _empleadoRepositorio.Obtener(u => u.Codigo == id);

                if (empleadoEncontrado == null)
                {
                    throw new TaskCanceledException("El empleado no existe.");
                }

                bool response = await _empleadoRepositorio.Eliminar(empleadoEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El empleado no pudo ser eliminado.");
                }

                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}
