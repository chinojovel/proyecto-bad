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
    public class RolService : IRolService
    {
        private readonly IGenericRepository<Rol> _rolRepositorio;
        private readonly IMapper _mapper;

        private readonly IGenericRepository<PermisoRol> _permisoRolRepositorio;
        private readonly IRolRepository _rolPermisoRepositorio;

        public RolService(IGenericRepository<Rol> rolRepositorio, IMapper mapper, IGenericRepository<PermisoRol> permisoRolRepositorio, IRolRepository rolPermisoRepositorio)
        {
            _rolRepositorio = rolRepositorio;
            _mapper = mapper;
            _permisoRolRepositorio = permisoRolRepositorio;
            _rolPermisoRepositorio = rolPermisoRepositorio;
        }

        public async Task<List<RolDTO>> Listar()
        {
            try
            {
                var listaRoles = await _rolRepositorio.Consultar();

                return _mapper.Map<List<RolDTO>>(listaRoles.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<RolDTO> Crear(RolDTO modelo)
        {
            try
            {
                var rolCreado = await _rolRepositorio.Crear(_mapper.Map<Rol>(modelo));

                if (rolCreado.Codigo == 0)
                {
                    throw new TaskCanceledException("El rol no pudo ser creado.");
                }

                return _mapper.Map<RolDTO>(rolCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(RolDTO modelo)
        {
            var rolModelo = _mapper.Map<Rol>(modelo);
            var rolEncontrado = await _rolRepositorio.Obtener(u => u.Codigo == rolModelo.Codigo);

            if (rolEncontrado == null)
            {
                throw new TaskCanceledException("El rol no existe.");
            }

            rolEncontrado.Nombre = rolModelo.Nombre;

            bool response = await _rolRepositorio.Editar(rolEncontrado);

            if (!response)
            {
                throw new TaskCanceledException("El rol no pudo ser editado.");
            }

            return response;
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var rolEncontrado = await _rolRepositorio.Obtener(u => u.Codigo == id);

                if (rolEncontrado == null)
                {
                    throw new TaskCanceledException("El rol no existe.");
                }

                bool response = await _rolRepositorio.Eliminar(rolEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El rol no pudo ser eliminado.");
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
