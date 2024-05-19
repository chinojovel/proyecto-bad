using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface ICentroCostoService
    {
        Task<List<CentroCostoDTO>> Listar();

        Task<CentroCostoDTO> Crear(CentroCostoDTO modelo);

        Task<bool> Editar(CentroCostoDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
