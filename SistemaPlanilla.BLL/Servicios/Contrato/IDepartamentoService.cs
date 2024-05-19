using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPlanilla.DTO;

namespace SistemaPlanilla.BLL.Servicios.Contrato
{
    public interface IDepartamentoService
    {
        Task<List<DepartamentoDTO>> Listar();

        Task<DepartamentoDTO> Crear(DepartamentoDTO modelo);

        Task<bool> Editar(DepartamentoDTO modelo);

        Task<bool> Eliminar(int id);
    }
}
