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
    public class CentroCostoService : ICentroCostoService
    {
        private readonly IGenericRepository<CentroCosto> _centroCostoRepositorio;
        private readonly IMapper _mapper;

        public CentroCostoService(IGenericRepository<CentroCosto> centroCostoRepositorio, IMapper mapper)
        {
            _centroCostoRepositorio = centroCostoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<CentroCostoDTO>> Listar()
        {
            try
            {
                var queryCentroCosto = await _centroCostoRepositorio.Consultar();
                var listaCentroCostos = queryCentroCosto.Include(f => f.CodDptoNavigation).ToList();

                return _mapper.Map<List<CentroCostoDTO>>(listaCentroCostos.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<CentroCostoDTO> Crear(CentroCostoDTO modelo)
        {
            try
            {
                var centroCostoCreado = await _centroCostoRepositorio.Crear(_mapper.Map<CentroCosto>(modelo));

                if (centroCostoCreado.Codigo == 0)
                {
                    throw new TaskCanceledException("El centro de costo no pudo ser creado.");
                }

                return _mapper.Map<CentroCostoDTO>(centroCostoCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(CentroCostoDTO modelo)
        {
            try
            {
                var centroCostoModelo = _mapper.Map<CentroCosto>(modelo);
                var centroCostoEncontrado = await _centroCostoRepositorio.Obtener(u => u.Codigo == centroCostoModelo.Codigo);

                if (centroCostoEncontrado == null)
                {
                    throw new TaskCanceledException("El centro de costo no existe.");
                }

                centroCostoEncontrado.FechaAsignacion = centroCostoModelo.FechaAsignacion;
                centroCostoEncontrado.MontoInicial = centroCostoModelo.MontoInicial;
                centroCostoEncontrado.MontoActual = centroCostoModelo.MontoActual;
                centroCostoEncontrado.CodDpto = centroCostoModelo.CodDpto;

                bool response = await _centroCostoRepositorio.Editar(centroCostoEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El centro de costo no pudo ser editado.");
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
                var centroCostoEncontrado = await _centroCostoRepositorio.Obtener(u => u.Codigo == id);

                if (centroCostoEncontrado == null)
                {
                    throw new TaskCanceledException("El centro de costo no existe.");
                }

                bool response = await _centroCostoRepositorio.Eliminar(centroCostoEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El centro de costo no pudo ser eliminado.");
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
