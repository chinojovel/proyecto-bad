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
    public class PermisoService : IPermisoService
    {
        private readonly IGenericRepository<Permiso> _permisoRepositorio;
        private readonly IMapper _mapper;

        public PermisoService(IGenericRepository<Permiso> permisoRepositorio, IMapper mapper)
        {
            _permisoRepositorio = permisoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<PermisoDTO>> Listar()
        {
            try
            {
                var listaPermisos = await _permisoRepositorio.Consultar();

                return _mapper.Map<List<PermisoDTO>>(listaPermisos.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<PermisoDTO> Crear(PermisoDTO modelo)
        {
            try
            {
                var permisoCreado = await _permisoRepositorio.Crear(_mapper.Map<Permiso>(modelo));

                if (permisoCreado.Codigo == 0)
                {
                    throw new TaskCanceledException("El permiso no pudo ser creado.");
                }

                return _mapper.Map<PermisoDTO>(permisoCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(PermisoDTO modelo)
        {
            try
            {
                var permisoModelo = _mapper.Map<Permiso>(modelo);
                var permisoEncontrado = await _permisoRepositorio.Obtener(u => u.Codigo == permisoModelo.Codigo);

                if (permisoEncontrado ==  null)
                {
                    throw new TaskCanceledException("El permiso no existe.");
                }

                permisoEncontrado.Nombre = permisoModelo.Nombre;

                bool response = await _permisoRepositorio.Editar(permisoEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El permiso no pudo ser editado.");
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
                var permisoEncontrado = await _permisoRepositorio.Obtener(u => u.Codigo == id);

                if (permisoEncontrado == null)
                {
                    throw new TaskCanceledException("El permiso no existe.");
                }

                bool response = await _permisoRepositorio.Eliminar(permisoEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El permiso no pudo ser eliminado.");
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
