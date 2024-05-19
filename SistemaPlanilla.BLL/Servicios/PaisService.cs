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
    public class PaisService : IPaisService
    {
        private readonly IGenericRepository<Pais> _paisRepositorio;
        private readonly IMapper _mapper;

        public PaisService(IGenericRepository<Pais> paisRepositorio, IMapper mapper)
        {
            _paisRepositorio = paisRepositorio;
            _mapper = mapper;
        }

        public async Task<List<PaisDTO>> Listar()
        {
            try
            {
                var listaPaises = await _paisRepositorio.Consultar();

                return _mapper.Map<List<PaisDTO>>(listaPaises.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<PaisDTO> Crear(PaisDTO modelo)
        {
            try
            {
                var paisCreado = await _paisRepositorio.Crear(_mapper.Map<Pais>(modelo));

                if (paisCreado.Codigo == 0)
                {
                    throw new TaskCanceledException("El país no pudo ser creado.");
                }

                return _mapper.Map<PaisDTO>(paisCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(PaisDTO modelo)
        {
            try
            {
                var paisModelo = _mapper.Map<Pais>(modelo);
                var paisEncontrado = await _paisRepositorio.Obtener(u => u.Codigo == paisModelo.Codigo);

                if (paisEncontrado == null)
                {
                    throw new TaskCanceledException("El país no existe.");
                }

                paisEncontrado.Nombre = paisModelo.Nombre;

                bool response = await _paisRepositorio.Editar(paisEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El país no pudo ser editado.");
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
                var paisEncontrado = await _paisRepositorio.Obtener(u => u.Codigo == id);

                if (paisEncontrado == null)
                {
                    throw new TaskCanceledException("El país no existe.");
                }

                bool response = await _paisRepositorio.Eliminar(paisEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El país no pudo ser eliminado.");
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
