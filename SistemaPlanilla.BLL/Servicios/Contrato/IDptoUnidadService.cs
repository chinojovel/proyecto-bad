using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IDptoUnidadService
    {
        Task<List<DptoUnidadDTO>> Listar();

        Task<DptoUnidadDTO> Crear(DptoUnidadDTO modelo);

        Task<bool> Editar(DptoUnidadDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
