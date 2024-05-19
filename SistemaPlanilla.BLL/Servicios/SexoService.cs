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
    public class SexoService : ISexoService
    {
        private readonly IGenericRepository<Sexo> _sexoRepositorio;
        private readonly IMapper _mapper;

        public SexoService(IGenericRepository<Sexo> sexoRepositorio, IMapper mapper)
        {
            _sexoRepositorio = sexoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<SexoDTO>> Listar()
        {
            try
            {
                var listaSexos = await _sexoRepositorio.Consultar();

                return _mapper.Map<List<SexoDTO>>(listaSexos.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<SexoDTO> Crear(SexoDTO modelo)
        {
            try
            {
                var sexoCreado = await _sexoRepositorio.Crear(_mapper.Map<Sexo>(modelo));

                if (sexoCreado.Codigo == 0)
                {
                    throw new TaskCanceledException("El sexo no pudo ser creado.");
                }

                return _mapper.Map<SexoDTO>(sexoCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(SexoDTO modelo)
        {
            try
            {
                var sexoModelo = _mapper.Map<Sexo>(modelo);
                var sexoEncontrado = await _sexoRepositorio.Obtener(u => u.Codigo == sexoModelo.Codigo);

                if (sexoEncontrado == null)
                {
                    throw new TaskCanceledException("El sexo no existe.");
                }

                sexoEncontrado.Nombre = sexoModelo.Nombre;

                bool response = await _sexoRepositorio.Eliminar(sexoEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El sexo no pudo ser editado.");
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
                var sexoEncontrado = await _sexoRepositorio.Obtener(u => u.Codigo == id);

                if (sexoEncontrado == null)
                {
                    throw new TaskCanceledException("El sexo no existe.");
                }

                bool response = await _sexoRepositorio.Editar(sexoEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El sexo no pudo ser eliminado.");
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
