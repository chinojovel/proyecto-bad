using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IPuestoService
    {
        Task<List<PuestoDTO>> Listar();

        Task<PuestoDTO> Crear(PuestoDTO modelo);

        Task<bool> Editar(PuestoDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
