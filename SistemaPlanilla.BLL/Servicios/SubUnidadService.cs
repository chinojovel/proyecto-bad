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
    public class SubUnidadService : ISubUnidadService
    {
        private readonly IGenericRepository<SubUnidad> _subUnidadRepositorio;
        private readonly IMapper _mapper;

        public SubUnidadService(IGenericRepository<SubUnidad> subUnidadRepositorio, IMapper mapper)
        {
            _subUnidadRepositorio = subUnidadRepositorio;
            _mapper = mapper;
        }

        public async Task<List<SubUnidadDTO>> Listar()
        {
            try
            {
                var querySubUnidad = await _subUnidadRepositorio.Consultar();
                var listaSubAreas = querySubUnidad.Include(f => f.CodAreaNavigation).Include(f => f.CodUnidadPadreNavigation).ToList();

                return _mapper.Map<List<SubUnidadDTO>>(listaSubAreas.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<SubUnidadDTO> Crear(SubUnidadDTO modelo)
        {
            try
            {
                var subUnidadCreada = await _subUnidadRepositorio.Crear(_mapper.Map<SubUnidad>(modelo));

                if (subUnidadCreada.Codigo == 0)
                {
                    throw new TaskCanceledException("La sub unidad no pudo ser creada.");
                }

                return _mapper.Map<SubUnidadDTO>(subUnidadCreada);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(SubUnidadDTO modelo)
        {
            try
            {
                var subUnidadModelo = _mapper.Map<SubUnidad>(modelo);
                var subUnidadEncontrada = await _subUnidadRepositorio.Obtener(u => u.Codigo == subUnidadModelo.Codigo);

                if (subUnidadEncontrada == null)
                {
                    throw new TaskCanceledException("La sub unidad no existe.");
                }

                subUnidadEncontrada.Nombre = subUnidadModelo.Nombre;
                subUnidadEncontrada.CodArea = subUnidadModelo.CodArea;
                subUnidadEncontrada.CodUnidadPadre = subUnidadModelo.CodUnidadPadre;

                bool response = await _subUnidadRepositorio.Editar(subUnidadEncontrada);

                if (!response)
                {
                    throw new TaskCanceledException("La sub unidad no pudo ser editada.");
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
                var subAreaEncontrada = await _subUnidadRepositorio.Obtener(u => u.Codigo == id);

                if (subAreaEncontrada == null)
                {
                    throw new TaskCanceledException("La sub unidad no existe.");
                }

                bool response = await _subUnidadRepositorio.Eliminar(subAreaEncontrada);

                if (!response)
                {
                    throw new TaskCanceledException("La sub unidad no pudo ser eliminada.");
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
