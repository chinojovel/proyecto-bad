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
    public class ProfesionOficioService : IProfesionOficioService
    {
        private readonly IGenericRepository<ProfesionOficio> _profesionOficioRepositorio;
        private readonly IMapper _mapper;

        public ProfesionOficioService(IGenericRepository<ProfesionOficio> profesionOficioRepositorio, IMapper mapper)
        {
            _profesionOficioRepositorio = profesionOficioRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ProfesionOficioDTO>> Listar()
        {
            try
            {
                var listaProfesiones = await _profesionOficioRepositorio.Consultar();

                return _mapper.Map<List<ProfesionOficioDTO>>(listaProfesiones.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProfesionOficioDTO> Crear(ProfesionOficioDTO modelo)
        {
            try
            {
                var profesionCreada = await _profesionOficioRepositorio.Crear(_mapper.Map<ProfesionOficio>(modelo));

                if (profesionCreada.Codigo == 0)
                {
                    throw new TaskCanceledException("La profesión/oficio no pudo ser creada.");
                }

                return _mapper.Map<ProfesionOficioDTO>(profesionCreada);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ProfesionOficioDTO modelo)
        {
            try
            {
                var profesionModelo = _mapper.Map<ProfesionOficio>(modelo);
                var profesionEncontrada = await _profesionOficioRepositorio.Obtener(u => u.Codigo == profesionModelo.Codigo);

                if (profesionEncontrada == null)
                {
                    throw new TaskCanceledException("La profesión/oficio no existe.");
                }

                profesionEncontrada.Nombre = profesionModelo.Nombre;

                bool response = await _profesionOficioRepositorio.Editar(profesionEncontrada);

                if (!response)
                {
                    throw new TaskCanceledException("La profesión/oficio no pudo ser editada.");
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
                var profesionEncontrado = await _profesionOficioRepositorio.Obtener(u => u.Codigo == id);

                if (profesionEncontrado == null)
                {
                    throw new TaskCanceledException("La profesión/oficio no existe.");
                }

                bool response = await _profesionOficioRepositorio.Eliminar(profesionEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("La profesión/oficio no pudo ser eliminada.");
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
