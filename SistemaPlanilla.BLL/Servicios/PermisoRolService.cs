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
    public class PermisoRolService : IPermisoRolService
    {
        private readonly IGenericRepository<PermisoRol> _permisoRolRepositorio;
        private readonly IMapper _mapper;

        public PermisoRolService(IGenericRepository<PermisoRol> permisoRolRepositorio, IMapper mapper)
        {
            _permisoRolRepositorio = permisoRolRepositorio;
            _mapper = mapper;
        }

        public async Task<List<PermisoRolDTO>> Listar()
        {
            try
            {
                var queryPermisoRol = await _permisoRolRepositorio.Consultar();
                var listaPermisoRol = queryPermisoRol
                    .Include(f => f.CodRolNavigation)
                    .Include(f => f.CodPermisoNavigation)
                    .ToList();

                return _mapper.Map<List<PermisoRolDTO>>(listaPermisoRol.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<PermisoRolDTO> Crear(PermisoRolDTO modelo)
        {
            try
            {
                var permisoRolCreado = await _permisoRolRepositorio.Crear(_mapper.Map<PermisoRol>(modelo));

                if (permisoRolCreado.Codigo == 0)
                {
                    throw new TaskCanceledException("El permiso no pudo ser asignado al rol.");
                }

                return _mapper.Map<PermisoRolDTO>(permisoRolCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(PermisoRolDTO modelo)
        {
            try
            {
                var permisoRolModelo = _mapper.Map<PermisoRol>(modelo);
                var permisoRolEncontrado = await _permisoRolRepositorio.Obtener(u => u.Codigo == permisoRolModelo.Codigo);

                if (permisoRolEncontrado == null)
                {
                    throw new TaskCanceledException("El registro no existe.");
                }

                permisoRolEncontrado.CodRol = permisoRolModelo.CodRol;
                permisoRolEncontrado.CodPermiso = permisoRolModelo.CodPermiso;

                bool response = await _permisoRolRepositorio.Editar(permisoRolEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El registro no pudo ser editado.");
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
                var permisoRolEncontrado = await _permisoRolRepositorio.Obtener(u => u.Codigo == id);

                if (permisoRolEncontrado == null)
                {
                    throw new TaskCanceledException("El registro no existe.");
                }

                bool response = await _permisoRolRepositorio.Eliminar(permisoRolEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El registro no pudo ser eliminado.");
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
