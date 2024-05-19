using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IEmpleadoService
    {
        Task<List<EmpleadoDTO>> Listar();

        Task<EmpleadoDTO> Crear(EmpleadoDTO modelo);

        Task<bool> Editar(EmpleadoDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
