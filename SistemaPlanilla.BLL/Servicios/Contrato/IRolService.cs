using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IRolService
    {
        Task<List<RolDTO>> Listar();

        Task<RolDTO> Crear(RolDTO modelo);

        Task<bool> Editar(RolDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
