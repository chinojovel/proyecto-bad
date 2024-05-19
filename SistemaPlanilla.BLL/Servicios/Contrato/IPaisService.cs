using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IPaisService
    {
        Task<List<PaisDTO>> Listar();

        Task<PaisDTO> Crear(PaisDTO modelo);

        Task<bool> Editar(PaisDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
