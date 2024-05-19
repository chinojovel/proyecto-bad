using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface ISubUnidadService
    {
        Task<List<SubUnidadDTO>> Listar();

        Task<SubUnidadDTO> Crear(SubUnidadDTO modelo);

        Task<bool> Editar(SubUnidadDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
