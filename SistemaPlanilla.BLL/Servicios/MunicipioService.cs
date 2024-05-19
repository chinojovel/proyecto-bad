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
    public class MunicipioService : IMunicipioService
    {
        private readonly IGenericRepository<Municipio> _municipioRepositorio;
        private readonly IMapper _mapper;

        public MunicipioService(IGenericRepository<Municipio> municipioRepositorio, IMapper mapper)
        {
            _municipioRepositorio = municipioRepositorio;
            _mapper = mapper;
        }

        public async Task<List<MunicipioDTO>> Listar()
        {
            try
            {
                var queryMunicipio = await _municipioRepositorio.Consultar();
                var listaMunicipios = queryMunicipio.Include(f => f.CodDepartamentoNavigation).ToList();

                return _mapper.Map<List<MunicipioDTO>>(listaMunicipios.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<MunicipioDTO> Crear(MunicipioDTO modelo)
        {
            try
            {
                var municipioCreado = await _municipioRepositorio.Crear(_mapper.Map<Municipio>(modelo));

                if (municipioCreado.Codigo == 0)
                {
                    throw new TaskCanceledException("El municipio no pudo ser creado.");
                }

                return _mapper.Map<MunicipioDTO>(municipioCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(MunicipioDTO modelo)
        {
            try
            {
                var municipioModelo = _mapper.Map<Municipio>(modelo);
                var municipioEncontrado = await _municipioRepositorio.Obtener(u => u.Codigo == municipioModelo.Codigo);

                if (municipioEncontrado == null)
                {
                    throw new TaskCanceledException("El municipio no existe.");
                }

                municipioEncontrado.Nombre = municipioModelo.Nombre;
                municipioEncontrado.CodDepartamento = municipioModelo.CodDepartamento;

                bool response = await _municipioRepositorio.Editar(municipioEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El municipio no pudo ser editado.");
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
                var municipioEncontrado = await _municipioRepositorio.Obtener(u => u.Codigo == id);

                if (municipioEncontrado == null)
                {
                    throw new TaskCanceledException("El municipio no existe.");
                }

                bool response = await _municipioRepositorio.Eliminar(municipioEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El municipio no pudo ser eliminado.");
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
