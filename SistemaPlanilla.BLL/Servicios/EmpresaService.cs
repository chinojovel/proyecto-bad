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
    public class EmpresaService : IEmpresaService
    {
        private readonly IGenericRepository<Empresa> _empresaRepositorio;
        private readonly IMapper _mapper;

        public EmpresaService(IGenericRepository<Empresa> empresaRepositorio, IMapper mapper)
        {
            _empresaRepositorio = empresaRepositorio;
            _mapper = mapper;
        }

        public async Task<List<EmpresaDTO>> Listar()
        {
            try
            {
                var queryEmpresa = await _empresaRepositorio.Consultar();
                var listaEmpresas = queryEmpresa.Include(f => f.CodMunicipioNavigation).ToList();

                return _mapper.Map<List<EmpresaDTO>>(listaEmpresas.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<EmpresaDTO> Crear(EmpresaDTO modelo)
        {
            try
            {
                var empresaCreada = await _empresaRepositorio.Crear(_mapper.Map<Empresa>(modelo));

                if (empresaCreada.Codigo == 0)
                {
                    throw new TaskCanceledException("La empresa no pudo ser creada.");
                }

                return _mapper.Map<EmpresaDTO>(empresaCreada);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(EmpresaDTO modelo)
        {
            try
            {
                var empresaModelo = _mapper.Map<Empresa>(modelo);
                var empresaEncontrada = await _empresaRepositorio.Obtener(u => u.Codigo == empresaModelo.Codigo);

                if (empresaEncontrada == null)
                {
                    throw new TaskCanceledException("La empresa no existe.");
                }

                empresaEncontrada.Nit = empresaModelo.Nit;
                empresaEncontrada.Nombre = empresaModelo.Nombre;
                empresaEncontrada.Representante = empresaModelo.Representante;
                empresaEncontrada.CodMunicipio = empresaModelo.CodMunicipio;
                empresaEncontrada.Direccion = empresaModelo.Direccion;
                empresaEncontrada.Telefono = empresaModelo.Telefono;
                empresaEncontrada.PaginaWeb = empresaModelo.PaginaWeb;
                empresaEncontrada.Email = empresaModelo.Email;
                empresaEncontrada.PlanillaMensual = empresaModelo.PlanillaMensual;

                bool response = await _empresaRepositorio.Editar(empresaEncontrada);

                if (!response)
                {
                    throw new TaskCanceledException("La empresa no pudo ser editada.");
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
                var empresaEncontrada = await _empresaRepositorio.Obtener(u => u.Codigo == id);

                if (empresaEncontrada == null)
                {
                    throw new TaskCanceledException("La empresa no existe.");
                }

                bool response = await _empresaRepositorio.Eliminar(empresaEncontrada);

                if (!response)
                {
                    throw new TaskCanceledException("La empresa no pudo ser eliminada.");
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
