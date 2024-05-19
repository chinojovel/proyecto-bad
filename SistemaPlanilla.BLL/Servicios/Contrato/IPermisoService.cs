using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IPermisoService
    {
        Task<List<PermisoDTO>> Listar();

        Task<PermisoDTO> Crear(PermisoDTO modelo);

        Task<bool> Editar(PermisoDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
