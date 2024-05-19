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
    public class PlanillaService : IPlanillaService
    {
        private readonly IGenericRepository<Planilla> _planillaRepositorio;
        private readonly IMapper _mapper;

        public PlanillaService(IGenericRepository<Planilla> planillaRepositorio, IMapper mapper)
        {
            _planillaRepositorio = planillaRepositorio;
            _mapper = mapper;
        }

        public async Task<List<PlanillaDTO>> Listar()
        {
            try
            {
                var queryPlanilla = await _planillaRepositorio.Consultar();
                var listaPlanillas = queryPlanilla.Include(f => f.CodEmpresaNavigation).Include(f => f.CodEmpleadoNavigation).ToList();

                return _mapper.Map<List<PlanillaDTO>>(listaPlanillas.ToList());
            }
            catch
            {
                throw;
            }
        }

        public async Task<PlanillaDTO> Crear(PlanillaDTO modelo)
        {
            try
            {
                var planillaCreada = await _planillaRepositorio.Crear(_mapper.Map<Planilla>(modelo));

                if (planillaCreada.Codigo == 0)
                {
                    throw new TaskCanceledException("La planilla no pudo ser creada.");
                }

                return _mapper.Map<PlanillaDTO>(planillaCreada);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(PlanillaDTO modelo)
        {
            try
            {
                var planillaModelo = _mapper.Map<Planilla>(modelo);
                var planillaEncontrado = await _planillaRepositorio.Obtener(u => u.Codigo == planillaModelo.Codigo);

                if (planillaEncontrado == null)
                {
                    throw new TaskCanceledException("La planilla no existe.");
                }

                planillaEncontrado.CodEmpresa = planillaModelo.CodEmpresa;
                planillaEncontrado.CodEmpleado = planillaModelo.CodEmpleado;
                planillaEncontrado.HorasExtrasDiurnas = planillaModelo.HorasExtrasDiurnas;
                planillaEncontrado.HorasExtrasNocturnas = planillaModelo.HorasExtrasNocturnas;
                planillaEncontrado.HorasNocturnas = planillaModelo.HorasNocturnas;

                bool response = await _planillaRepositorio.Editar(planillaEncontrado);

                if (!response)
                {
                    throw new TaskCanceledException("La planilla no pudo ser editada.");
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
                var planillaEncontrada = await _planillaRepositorio.Obtener(u => u.Codigo == id);

                if (planillaEncontrada == null)
                {
                    throw new TaskCanceledException("La planilla no existe.");
                }

                bool response = await _planillaRepositorio.Eliminar(planillaEncontrada);

                if (!response)
                {
                    throw new TaskCanceledException("La planilla no pudo ser eliminada.");
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
