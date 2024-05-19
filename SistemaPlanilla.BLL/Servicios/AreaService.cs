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
    public class AreaService : IAreaService
    {
        private readonly IGenericRepository<Area> _areaRepositorio;
        private readonly IMapper _mapper;

        public AreaService(IGenericRepository<Area> areaRepositorio, IMapper mapper)
        {
            _areaRepositorio = areaRepositorio;
            _mapper = mapper;
        }

        public async Task<List<AreaDTO>> Listar()
        {
            try
            {
                var queryArea = await _areaRepositorio.Consultar();
                var listaAreas = queryArea.Include(f => f.CodDptoNavigation).ToList();

                return _mapper.Map<List<AreaDTO>>(listaAreas.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<AreaDTO> Crear(AreaDTO modelo)
        {
            try
            {
                var areaCreada = await _areaRepositorio.Crear(_mapper.Map<Area>(modelo));

                if (areaCreada.Codigo == 0)
                {
                    throw new TaskCanceledException("El área no pudo ser creada.");
                }

                return _mapper.Map<AreaDTO>(areaCreada);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(AreaDTO modelo)
        {
            try
            {
                var areaModelo = _mapper.Map<Area>(modelo);
                var areaEncontrada = await _areaRepositorio.Obtener(u => u.Codigo == areaModelo.Codigo);

                if (areaEncontrada == null)
                {
                    throw new TaskCanceledException("El área no existe.");
                }

                areaEncontrada.Nombre = areaModelo.Nombre;
                areaEncontrada.CodDpto = areaModelo.CodDpto;

                bool response = await _areaRepositorio.Editar(areaEncontrada);

                if (!response)
                {
                    throw new TaskCanceledException("El área no pudo ser editada.");
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
                var areaEncontrada = await _areaRepositorio.Obtener(u => u.Codigo == id);

                if (areaEncontrada == null)
                {
                    throw new TaskCanceledException("El área no existe.");
                }

                bool response = await _areaRepositorio.Eliminar(areaEncontrada);

                if (!response)
                {
                    throw new TaskCanceledException("El área no pudo ser eliminada.");
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
