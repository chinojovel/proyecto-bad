using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IAreaService
    {
        Task<List<AreaDTO>> Listar();

        Task<AreaDTO> Crear(AreaDTO modelo);

        Task<bool> Editar(AreaDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
