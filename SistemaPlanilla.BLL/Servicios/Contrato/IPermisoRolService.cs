using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IPermisoRolService
    {
        Task<List<PermisoRolDTO>> Listar();

        Task<PermisoRolDTO> Crear(PermisoRolDTO modelo);

        Task<bool> Editar(PermisoRolDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
