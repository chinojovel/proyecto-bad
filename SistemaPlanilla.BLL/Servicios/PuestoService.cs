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
    public class PuestoService : IPuestoService
    {
        private readonly IGenericRepository<Puesto> _puestoRepositorio;
        private readonly IMapper _mapper;

        public PuestoService(IGenericRepository<Puesto> puestoRepositorio, IMapper mapper)
        {
            _puestoRepositorio = puestoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<PuestoDTO>> Listar()
        {
            try
            {
                var queryPuesto = await _puestoRepositorio.Consultar();
                var listaPuestos = queryPuesto.Include(f => f.CodEmpresaNavigation).Include(f => f.CodSubunidadNavigation).ToList();

                return _mapper.Map<List<PuestoDTO>>(listaPuestos.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<PuestoDTO> Crear(PuestoDTO modelo)
        {
            try
            {
                var puestoCreado = await _puestoRepositorio.Crear(_mapper.Map<Puesto>(modelo));

                if (puestoCreado.Codigo == 0)
                {
                    throw new TaskCanceledException("El puesto no pudo ser creado.");
                }

                return _mapper.Map<PuestoDTO>(puestoCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(PuestoDTO modelo)
        {
            try
            {
                var puestoModelo = _mapper.Map<Puesto>(modelo);
                var puestoEncontrado = await _puestoRepositorio.Obtener(u => u.Codigo == puestoModelo.Codigo);

                if (puestoEncontrado == null)
                {
                    throw new TaskCanceledException("El puesto no existe.");
                }

                puestoEncontrado.Nombre = puestoModelo.Nombre;
                puestoEncontrado.Descripcion = puestoModelo.Descripcion;
                puestoEncontrado.SalarioMin = puestoModelo.SalarioMin;
                puestoEncontrado.SalarioMax = puestoModelo.SalarioMax;
                puestoEncontrado.CodEmpresa = puestoModelo.CodEmpresa;
                puestoEncontrado.CodSubunidad = puestoModelo.CodSubunidad;

                bool response = await _puestoRepositorio.Editar(puestoEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El puesto no pudo ser editado.");
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
                var puestoEncontrado = await _puestoRepositorio.Obtener(u => u.Codigo == id);

                if (puestoEncontrado == null)
                {
                    throw new TaskCanceledException("El puesto no existe.");
                }

                bool response = await _puestoRepositorio.Eliminar(puestoEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El puesto no pudo ser eliminado.");
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
