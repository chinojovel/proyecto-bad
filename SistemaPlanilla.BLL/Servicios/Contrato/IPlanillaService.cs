using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IPlanillaService
    {
        Task<List<PlanillaDTO>> Listar();

        Task<PlanillaDTO> Crear(PlanillaDTO modelo);

        Task<bool> Editar(PlanillaDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
