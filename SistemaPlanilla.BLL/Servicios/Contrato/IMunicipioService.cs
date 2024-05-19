using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IMunicipioService
    {
        Task<List<MunicipioDTO>> Listar();

        Task<MunicipioDTO> Crear(MunicipioDTO modelo);

        Task<bool> Editar(MunicipioDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
