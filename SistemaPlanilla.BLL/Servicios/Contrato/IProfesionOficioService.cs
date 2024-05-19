using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IProfesionOficioService
    {
        Task<List<ProfesionOficioDTO>> Listar();

        Task<ProfesionOficioDTO> Crear(ProfesionOficioDTO modelo);

        Task<bool> Editar(ProfesionOficioDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
