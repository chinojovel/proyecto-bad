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
    public class DptoUnidadService : IDptoUnidadService
    {
        private readonly IGenericRepository<DptoUnidad> _dptoUnidadRepositorio;
        private readonly IMapper _mapper;

        public DptoUnidadService(IGenericRepository<DptoUnidad> dptoUnidadRepositorio, IMapper mapper)
        {
            _dptoUnidadRepositorio = dptoUnidadRepositorio;
            _mapper = mapper;
        }

        public async Task<List<DptoUnidadDTO>> Listar()
        {
            try
            {
                var queryDpto = await _dptoUnidadRepositorio.Consultar();
                var listaDptos = queryDpto.Include(f => f.CodEmpresaNavigation).ToList();

                return _mapper.Map<List<DptoUnidadDTO>>(listaDptos.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<DptoUnidadDTO> Crear(DptoUnidadDTO modelo)
        {
            try
            {
                var dptoCreado = await _dptoUnidadRepositorio.Crear(_mapper.Map<DptoUnidad>(modelo));

                if (dptoCreado.Codigo == 0)
                {
                    throw new TaskCanceledException("La unidad departamental no pudo ser creada.");
                }

                return _mapper.Map<DptoUnidadDTO>(dptoCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(DptoUnidadDTO modelo)
        {
            try
            {
                var dptoModelo = _mapper.Map<DptoUnidad>(modelo);
                var dptoEncontrado = await _dptoUnidadRepositorio.Obtener(u => u.Codigo == dptoModelo.Codigo);

                if (dptoEncontrado == null)
                {
                    throw new TaskCanceledException("La unidad departamental no existe.");
                }

                dptoEncontrado.Nombre = dptoModelo.Nombre;
                dptoEncontrado.CodEmpresa = dptoModelo.CodEmpresa;

                bool response = await _dptoUnidadRepositorio.Editar(dptoEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("La unidad departamental no pudo ser editada.");
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
                var dptoEncontrado = await _dptoUnidadRepositorio.Obtener(u => u.Codigo == id);

                if (dptoEncontrado == null)
                {
                    throw new TaskCanceledException("La unidad departamental no existe.");
                }

                bool response = await _dptoUnidadRepositorio.Eliminar(dptoEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("La unidad departamental no pudo ser eliminada.");
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
