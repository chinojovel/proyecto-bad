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
    public class EstadoCivilService : IEstadoCivilService
    {
        private readonly IGenericRepository<EstadoCivil> _estadoCivilRepositorio;
        private readonly IMapper _mapper;

        public EstadoCivilService(IGenericRepository<EstadoCivil> estadoCivilRepositorio, IMapper mapper)
        {
            _estadoCivilRepositorio = estadoCivilRepositorio;
            _mapper = mapper;
        }

        public async Task<List<EstadoCivilDTO>> Listar()
        {
            try
            {
                var listaEstadosCiviles = await _estadoCivilRepositorio.Consultar();

                return _mapper.Map<List<EstadoCivilDTO>>(listaEstadosCiviles.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<EstadoCivilDTO> Crear(EstadoCivilDTO modelo)
        {
            try
            {
                var estadoCivilCreado = await _estadoCivilRepositorio.Crear(_mapper.Map<EstadoCivil>(modelo));

                if (estadoCivilCreado.Codigo == 0)
                {
                    throw new TaskCanceledException("El estado civil no pudo ser creado.");
                }

                return _mapper.Map<EstadoCivilDTO>(estadoCivilCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(EstadoCivilDTO modelo)
        {
            var estadoCivilModelo = _mapper.Map<EstadoCivil>(modelo);
            var estadoCivilEncontrado = await _estadoCivilRepositorio.Obtener(u => u.Codigo == estadoCivilModelo.Codigo);

            if (estadoCivilEncontrado == null)
            {
                throw new TaskCanceledException("El estado civil no existe.");
            }

            estadoCivilEncontrado.Nombre = estadoCivilModelo.Nombre;

            bool response = await _estadoCivilRepositorio.Editar(estadoCivilEncontrado);

            if (!response)
            {
                throw new TaskCanceledException("El estado civil no pudo ser editado.");
            }

            return response;
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var estadoCivilEncontrado = await _estadoCivilRepositorio.Obtener(u => u.Codigo == id);

                if (estadoCivilEncontrado == null)
                {
                    throw new TaskCanceledException("El estado civil no existe.");
                }

                bool response = await _estadoCivilRepositorio.Eliminar(estadoCivilEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El estado civil no pudo ser eliminado.");
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
