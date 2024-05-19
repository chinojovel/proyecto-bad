using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IEstadoCivilService
    {
        Task<List<EstadoCivilDTO>> Listar();

        Task<EstadoCivilDTO> Crear(EstadoCivilDTO modelo);

        Task<bool> Editar(EstadoCivilDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
