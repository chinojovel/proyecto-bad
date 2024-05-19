using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface ISexoService
    {
        Task<List<SexoDTO>> Listar();

        Task<SexoDTO> Crear(SexoDTO modelo);

        Task<bool> Editar(SexoDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
