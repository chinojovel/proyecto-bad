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
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IGenericRepository<Departamento> _departamentoRepositorio;
        private readonly IMapper _mapper;

        public DepartamentoService(IGenericRepository<Departamento> departamentoRepositorio, IMapper mapper)
        {
            _departamentoRepositorio = departamentoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<DepartamentoDTO>> Listar()
        {
            try
            {
                var queryDepartamento = await _departamentoRepositorio.Consultar();
                var listaDepartamentos = queryDepartamento.Include(f => f.CodPaisNavigation).ToList();

                return _mapper.Map<List<DepartamentoDTO>>(listaDepartamentos.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<DepartamentoDTO> Crear(DepartamentoDTO modelo)
        {
            try
            {
                var departamentoCreado = await _departamentoRepositorio.Crear(_mapper.Map<Departamento>(modelo));

                if (departamentoCreado.Codigo == 0)
                {
                    throw new TaskCanceledException("El departamento no pudo ser creado.");
                }

                return _mapper.Map<DepartamentoDTO>(departamentoCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(DepartamentoDTO modelo)
        {
            try
            {
                var departamentoModelo = _mapper.Map<Departamento>(modelo);
                var departamentoEncontrado = await _departamentoRepositorio.Obtener(u => u.Codigo == departamentoModelo.Codigo);

                if (departamentoEncontrado == null)
                {
                    throw new TaskCanceledException("El departamento no existe.");
                }

                departamentoEncontrado.Nombre = departamentoModelo.Nombre;
                departamentoEncontrado.CodPais = departamentoModelo.CodPais;

                bool response = await _departamentoRepositorio.Editar(departamentoEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El departamento no pudo ser editado.");
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
                var departamentoEncontrado = await _departamentoRepositorio.Obtener(u => u.Codigo == id);

                if (departamentoEncontrado == null)
                {
                    throw new TaskCanceledException("El departamento no existe.");
                }

                bool response = await _departamentoRepositorio.Eliminar(departamentoEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("El departamento no pudo ser eliminado.");
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
